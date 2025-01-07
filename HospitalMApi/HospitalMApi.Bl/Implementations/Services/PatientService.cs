using AutoMapper;
using HospitalMApi.Bl.Implementations.Interfaces;
using HospitalMApi.Dal.Implementations.RepositoryIntefaces;
using HospitalMApi.Model.DTOs.Patient;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Bl.Implementations.Services
{
    public class PatientService : IPatientService
    {

        private readonly IRepository<Patient> _patientService;
        private readonly IMapper _mapper;

        public PatientService(IRepository<Patient> patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        public async Task AddAsync(PatientCreateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Patient cannot be null.");
            }

            var patient = _mapper.Map<Patient>(entity);
            await _patientService.AddAsync(patient);

        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientService.GetAll();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await GetExistingEntity(id);
        }

        public async Task HardDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _patientService.HardDelete(id);

        }

        public async Task SoftDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _patientService.SoftDelete(id);

        }

        public async Task UpdateAsync(PatientUpdateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException( "Patient cannot be null.");
            }

            var existingPatient = await GetExistingEntity(entity.Id);

          

            var patient = _mapper.Map<Patient>(entity);

            await _patientService.Update(patient);

        }

        private async Task<Patient> GetExistingEntity(int id)
        {
            var patient = await _patientService.GetById(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with id {id} not found.");
            }
            return patient;
        }

    }
}
