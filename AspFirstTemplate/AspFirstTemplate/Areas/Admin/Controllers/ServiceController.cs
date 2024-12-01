using AspFirstTemplate.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspFirstTemplate.Models;
using Microsoft.EntityFrameworkCore;


namespace AspFirstTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext content)
        {
            _context = content;
        }
        public IActionResult Index()
        {
            IEnumerable<Service> services = _context.Services.ToList();

            return View(services);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        
        public IActionResult Create(Service service) {
           
            _context.Services.Add(service);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            
            Service? Service = _context.Services.Find(id);
            return View(nameof(Create), Service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            Service? UpdateService = _context.Services.AsNoTracking().FirstOrDefault(x => x.Id == service.Id);

            if (UpdateService is null)
            {
                return NotFound("Bele bir data yoxdur");
            }

            _context.Services.Update(service);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Service? service = _context.Services.Find(id);

            _context.Services.Remove(service);
            _context.SaveChanges();




            return RedirectToAction(nameof(Index));
        }
    }
}
