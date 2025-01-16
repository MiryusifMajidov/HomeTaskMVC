using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.Model.Dtos.DoctorsDtos
{
    public class GetDoctorDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
