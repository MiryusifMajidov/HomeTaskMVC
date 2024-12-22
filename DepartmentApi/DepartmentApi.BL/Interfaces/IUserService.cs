using DepartmentApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApi.BL.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetById(int id);
        Task<IEnumerable<AppUser>> GetAll();
    }
}
