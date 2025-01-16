using AutoMapper;
using FinalApojectTest4.BL.Implementations.Interfaces;
using FinalApojectTest4.Dal.Repositories;
using FinalApojectTest4.Model.Dtos.DepartmentDtos;
using FinalApojectTest4.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.BL.Implementations.Services
{
    public class DepartmentService:IDepartmentService
    {
        private IRepsitory<Department> _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepsitory<Department> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Delete(GetDepartmentDto entity)
        {
            Department departament = _mapper.Map<Department>(entity);
            _repository.Delete(departament);
            await _repository.SaveChangeAsync();
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetAll()
        {
            IEnumerable<Department> departments = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
        }

        public async Task<GetDepartmentDto> GetById(int id)
        {
            Department department =  await _repository.GetByIdAsync(id, true);

           return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task Update(GetDepartmentDto entity)
        {

            Department department =  _mapper.Map<Department>(entity);

            _repository.Update(department);
            await _repository.SaveChangeAsync();
        }

        public async Task CreateAsync(CreateDepartmentDto entity)
        {
           Department department =  _mapper.Map<Department>(entity);
           await _repository.CreateAsync(department);
            await _repository.SaveChangeAsync();
        }
    }
}
