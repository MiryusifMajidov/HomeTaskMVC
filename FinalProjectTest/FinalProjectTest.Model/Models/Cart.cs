using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Model.Models
{
    public class Cart:BaseEntity
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
    }
}
