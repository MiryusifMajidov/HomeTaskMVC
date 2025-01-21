using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.Model.Dtos.DoctorDtos
{
    public class DoctorGetDto
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
