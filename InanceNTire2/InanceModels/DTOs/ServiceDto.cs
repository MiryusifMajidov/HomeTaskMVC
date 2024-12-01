using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.DTOs
{
    public class ServiceDto
    {
        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Title")]
        public string Title { get; set; }
        [Required]
        [Length(3, 300)]
        [Display(Prompt = "Description")]
        public string Description { get; set; }
    }
}
