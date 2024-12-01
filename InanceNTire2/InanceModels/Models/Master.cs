using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.Models
{
    public class Master:BaseEntity
    {
        //Id, Name, Surname, Email, PhoneNumber, Username, ExperienceYear, IsActive, ServiceId

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public int ExperienceYear { get; set; }
        public bool IsActive { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
