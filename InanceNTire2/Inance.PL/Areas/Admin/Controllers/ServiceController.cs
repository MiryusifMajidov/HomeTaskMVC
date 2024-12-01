using InanceBL.Services.Interfaces;
using InanceModels.DTOs;
using InanceModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inance.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IService<Service> _serviceContext;

        public ServiceController(IService<Service> serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceContext.GetAllAsync();

            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceDto serviceDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceDTO);
            }
            Service service = new Service
            {
                Title = serviceDTO.Title,
                Description = serviceDTO.Description,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            await _serviceContext.AddAsync(service);
            
           
            return RedirectToAction(nameof(Index));
        }
    }
}
