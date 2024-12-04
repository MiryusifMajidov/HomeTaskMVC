using MediClub.BL.Services.Interfaces;
using MediClub.DAL.DAL;
using MediClubModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediClub.PL.Areas.Admin.Controllers
{
    public class HosbitalController : Controller
    {
        private readonly IService<Hospital> _service;
       

        public HosbitalController(IService<Hospital> service)
        {
            _service = service;
           
        }

        public async Task<IActionResult> Index()
        {
          
          
            return View();
        }
    }
}
