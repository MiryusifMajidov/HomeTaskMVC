using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTask1._1.Data;
using System.Text.RegularExpressions;



namespace MVCTask1._1.Controllers
{
    public class GroupController : Controller
    {
        private readonly AppDbContext _context;

        public GroupController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.Groups.Include(g => g.Teacher).ToList();
            return View(groups);
        }

        public IActionResult Create()
        {
            
            ViewBag.Teachers = _context.Teachers
                .Select(t => new { t.Id, t.Name }) 
                .ToList();

            return View();
        }




        [HttpPost]
        public IActionResult Create(MVCTask1._1.Models.Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(group); 
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

    }
}
