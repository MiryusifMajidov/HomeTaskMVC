using InanceModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.DTOs
{
    public class OrderDto
    {
        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Name")]
        public string ClientName { get; set; }

        [Required]
        [Length(3, 40)]
        [Display(Prompt = "SurName")]
        public string ClientSurname { get; set; }

        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Number")]
        public string ClientPhoneNumber { get; set; }

        [Required]
        [Length(3, 50)]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string ClientEmail { get; set; }

        [Required]
        [Length(3, 300)]
        [Display(Prompt = "Problem")]
        public string Problem { get; set; }

        [Required]
       
        public int ServiceId { get; set; }

        //[Required]

        public int MasterId { get; set; }

    }
}
