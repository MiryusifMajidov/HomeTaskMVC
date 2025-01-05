using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public IFormFile Image { get; set; }
    }
}
