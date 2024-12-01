using AspFirstTemplate.Data;
using AspFirstTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<OurTeam> ourTeams = _context.OurTeams.ToList(); ;
            return View(ourTeams);
        }
    }
}
