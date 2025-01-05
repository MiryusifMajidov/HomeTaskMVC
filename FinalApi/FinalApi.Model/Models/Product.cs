using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.Models
{
    public class Product:SoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
       
        public Color Color { get; set; }
        public Size Size { get; set; }
        public string Image {  get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
