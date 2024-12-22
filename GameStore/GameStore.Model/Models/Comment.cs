using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.Models
{
    public class Comment:BaseEntity
    {
        public string CommentMessage { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public Game Game { get; set; }
        public AppUser AppUser { get; set; }
    }
}
