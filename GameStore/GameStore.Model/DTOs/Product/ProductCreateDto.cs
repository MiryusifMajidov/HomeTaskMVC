using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required]
        [Display(Prompt = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Prompt = "Price")]

        public decimal Price { get; set; }

        [Required]
        [Display(Prompt = "Description")]

        public string Description { get; set; }

        [Required]
        [Display(Prompt = "Guantity")]
        public int Guantity { get; set; }

        [Required]
        [Display(Prompt = "GameId")]
        public string GameId { get; set; }
        [Required]
        public  IFormFile Image { get; set; }
    }
}
