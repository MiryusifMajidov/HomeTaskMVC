using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.Model.Dtos.DoctorDtos
{
    public class DoctorCreateDto
    {
        public string Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int DepartmentId { get; set; }
    }
}
