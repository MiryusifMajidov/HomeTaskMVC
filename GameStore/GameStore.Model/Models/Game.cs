using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.Models
{
    public class Game:BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }
        public string Description { get; set; }
        public int Guantity { get; set; }
        public string GameId { get; set; }
        public string Image { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
