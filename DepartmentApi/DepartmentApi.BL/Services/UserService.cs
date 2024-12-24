using DepartmentApi.BL.Interfaces;
using DepartmentApi.DAL.Interfaces;
using DepartmentApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApi.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _repository;

        public UserService(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AppUser>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<AppUser> GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Task<AppUser> GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}
