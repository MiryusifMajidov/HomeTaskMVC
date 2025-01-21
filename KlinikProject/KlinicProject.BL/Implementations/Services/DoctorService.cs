using AutoMapper;
using KlinicProject.BL.CustomExtension;
using KlinicProject.BL.Implementations.Interfaces;
using KlinicProject.Dal.Repositories;
using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Dtos.DoctorDtos;
using KlinicProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Implementations.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IMapper mapper, IRepository<Doctor> repository)
        {

            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(DoctorCreateDto entity)
        {
            string imagePath = await entity.ImageUrl.FileUpload("wwwroot/images", 5);
            Doctor doctor = _mapper.Map<Doctor>(entity);
            doctor.Image = imagePath;
            await _repository.CreateAsync(doctor);
            await _repository.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            Doctor doctor = await _repository.GetByIdAsync(id, true);

            if (doctor == null)
            {
                throw new Exception("Bele Doctor yoxdur");
            }

            _repository.Delete(doctor);

        }


        public async Task<IEnumerable<DoctorGetDto>> GetAllAsync()
        {
            IEnumerable<Doctor> doctor = await _repository.GetAllAsync();

            IEnumerable<DoctorGetDto> result = _mapper.Map<IEnumerable<DoctorGetDto>>(doctor);

            return result;


        }

        public async Task<DoctorGetDto> GetById(int id)
        {
            Doctor doctor = await _repository.GetByIdAsync(id, true);
            DoctorGetDto result = _mapper.Map<DoctorGetDto>(doctor);
            return result;
        }

        public async Task Update(DoctorCreateDto entity, int id)
        {

            Doctor doctor = _mapper.Map<Doctor>(entity);

            Doctor updateDoctor = await _repository.GetByIdAsync(id, true);

            if (entity.ImageUrl == null)
            {
                doctor.Image = updateDoctor.Image;
            }

            else
            {
                string imagePath = await entity.ImageUrl.FileUpload("wwwroot/images", 5);
                doctor.Image = imagePath;   

            }

            doctor.Id = id;
            _repository.Update(doctor);

        }
    }
}
