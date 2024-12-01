using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqloDAL.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}
