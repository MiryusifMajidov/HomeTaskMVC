using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.Model.Dtos.DepartmentDtos
{
    public class DepartmentGetDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
