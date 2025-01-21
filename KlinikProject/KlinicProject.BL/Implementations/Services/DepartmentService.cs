using AutoMapper;
using KlinicProject.BL.Implementations.Interfaces;
using KlinicProject.Dal.DAL;
using KlinicProject.Dal.Repositories;
using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;
        private readonly IMapper _mapper;

        public DepartmentService( IMapper mapper, IRepository<Department> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(DepartmentCreateDto entity)
        {
            Department department = _mapper.Map<Department>(entity);

           
            await _repository.CreateAsync(department);
            await _repository.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
           Department department =  await _repository.GetByIdAsync(id, true);

            if (department == null) 
            {
                throw new Exception("Bele department yoxdur");
            }

             _repository.Delete(department);
            await _repository.SaveChangeAsync();

        }

        public async Task<IEnumerable<DepartmentGetDto>> GetAllAsync()
        {
            IEnumerable<Department> departments = await _repository.GetAllAsync();

            IEnumerable<DepartmentGetDto> result = _mapper.Map<IEnumerable<DepartmentGetDto>>(departments);

            return result;


        }

        public async Task<DepartmentGetDto> GetById(int id)
        {
            Department department = await _repository.GetByIdAsync(id, true);
            DepartmentGetDto result = _mapper.Map<DepartmentGetDto>(department);
            return result;
        }

        public async Task Update(DepartmentCreateDto entity, int id)
        {
            Department department = _mapper.Map<Department>(entity);

            department.Id = id;
            _repository.Update(department);

            await _repository.SaveChangeAsync();

        }
    }
}
