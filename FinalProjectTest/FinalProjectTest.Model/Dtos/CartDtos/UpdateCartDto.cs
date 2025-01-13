using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Model.Dtos.CartDtos
{
    public class UpdateCartDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Prompt = "Title")]
        public string Tittle { get; set; }

        [Required]
        [Display(Prompt = "Desctipton")]

        public string Description { get; set; }


        [Required]
        [Display(Prompt = "Icon (Url formasinda daxil edin)")]
        public string Icon { get; set; }

       
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
