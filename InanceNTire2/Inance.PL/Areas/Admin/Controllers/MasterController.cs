using InanceBL.Services.Interfaces;
using InanceModels.Models;
using InanceModels.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace Inance.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterController : Controller
    {
        

        private readonly IService<Master> _masterContext;
        private readonly IService<Service> _ServiceContext;

        public MasterController(IService<Service> serviceContext, IService<Master> masterContext)
        {
            _ServiceContext = serviceContext;
            _masterContext = masterContext;
        }

        public async Task<IActionResult> Index()
        {
            var masters = await _masterContext.GetAllAsync();
            return View(masters);
        }

        public async Task<IActionResult> Create() 
        {
            ViewBag.Service = await _ServiceContext.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MasterDto masterDto) 
        {
            if (!ModelState.IsValid) 
            { 
                return View(masterDto);
            }
      

            Master master = new Master 
            { 
                Name = masterDto.Name,
                Surname = masterDto.Surname,
                Email = masterDto.Email,
                PhoneNumber = masterDto.PhoneNumber,
                Username = masterDto.Username,
                ExperienceYear = masterDto.ExperienceYear,
                ServiceId = masterDto.ServiceId,
                IsActive = true,
                CreatedAt = DateTime.Now,

            };

            await _masterContext.AddAsync(master);

            return RedirectToAction(nameof(Index));
        }
    }
}
