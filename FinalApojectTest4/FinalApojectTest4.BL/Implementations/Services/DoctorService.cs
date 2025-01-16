using AutoMapper;
using FinalApojectTest4.BL.Implementations.Interfaces;
using FinalApojectTest4.Dal.Repositories;
using FinalApojectTest4.Model.Dtos.DoctorsDtos;
using FinalApojectTest4.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.BL.Implementations.Services
{
    public class DoctorService:IDoctorService
    {
        private IRepsitory<Doctor> _repsitory;
        private readonly IMapper _mapper;

        public DoctorService(IRepsitory<Doctor> repsitory, IMapper mapper)
        {
            _repsitory = repsitory;
            _mapper = mapper;
        }

        public  async Task Delete(GetDoctorDto entity)
        {
            Doctor doctor =  _mapper.Map<Doctor>(entity);
            _repsitory.Delete(doctor);
            await _repsitory.SaveChangeAsync();
        }

        public async Task<IEnumerable<GetDoctorDto>> GetAll()
        {
            IEnumerable<Doctor> doctors =  await _repsitory.GetAllAsync();

            return _mapper.Map<IEnumerable<GetDoctorDto>>(doctors);

        }

        public async Task<GetDoctorDto> GetById(int id)
        {
            Doctor doctor = await _repsitory.GetByIdAsync(id,true);

            return _mapper.Map<GetDoctorDto>(doctor);
        }

        public async Task Update(GetDoctorDto entity)
        {
           Doctor doctor =  _mapper.Map<Doctor>(entity);
            _repsitory.Update(doctor);
        }

        public async Task CreateAsync(GetDoctorDto entity)
        {
            Doctor doctor = _mapper.Map<Doctor>(entity);
            await _repsitory.CreateAsync(doctor);
        }
    }
}
