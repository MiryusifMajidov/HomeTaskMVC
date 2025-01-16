using FinalApojectTest4.BL.Implementations.Interfaces;
using FinalApojectTest4.Model.Dtos.DepartmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalApojectTest4.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            //IEnumerable<GetDepartmentDto>

            return View();
        }

        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto dto) 
        {

             return RedirectToAction("Index");
        }
    }
}
