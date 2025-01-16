using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.Model.Dtos.DoctorsDtos
{
    public class UpdateDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
