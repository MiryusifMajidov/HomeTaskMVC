using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.Models
{
    public class Service:BaseEntity
    {
        // Id, Title, Description,IsActive, Masters, Orders, CreatedAt, UpdatedAt
        public string Title { get; set; }   
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Master> Masters { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
