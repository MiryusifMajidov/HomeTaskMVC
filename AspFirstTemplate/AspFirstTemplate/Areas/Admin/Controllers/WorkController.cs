using AspFirstTemplate.Data;
using AspFirstTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspFirstTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {

        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Work> works = _context.Works.ToList();
            return View(works);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Service = _context.Services
                 .Select(t => new { t.Id, t.Title })
                 .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Work work)
        {
           

            _context.Works.Add(work);   
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            ViewBag.Service = _context.Services
                 .Select(t => new { t.Id, t.Title })
                 .ToList();
           
            Work? Work = _context.Works.Find(id);
            return View(nameof(Create), Work);
        }

        [HttpPost]
        public IActionResult Edit(Work work) 
        { 
            Work? UpdateWork = _context.Works.AsNoTracking().FirstOrDefault(x=>x.Id == work.Id);

            if (UpdateWork is null)
            {
                return NotFound("Bele bir data yoxdur");  
            }

            _context.Works.Update(work);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) 
        { 
            Work? work = _context.Works.Find(id);
           
            _context.Works.Remove(work);
            _context.SaveChanges();
            
           


            return RedirectToAction(nameof(Index));
        }
    }
}
