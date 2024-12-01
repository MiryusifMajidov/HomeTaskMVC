using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTask1._1.Data;
using MVCTask1._1.Models;

namespace MVCTask1._1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.Group).ThenInclude(g => g.Teacher).ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList(); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
