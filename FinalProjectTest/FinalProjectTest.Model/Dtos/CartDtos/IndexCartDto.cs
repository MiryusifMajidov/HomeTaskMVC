using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Model.Dtos.CartDtos
{
    public class IndexCartDto
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
    }
}
