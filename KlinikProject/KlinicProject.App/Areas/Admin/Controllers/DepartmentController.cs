using AutoMapper;
using KlinicProject.BL.Implementations.Interfaces;
using KlinicProject.Model.Dtos.DepartmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace KlinicProject.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           IEnumerable<DepartmentGetDto> departament = await _departmentService.GetAllAsync();
            return View(departament);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto) 
        {
            if (!ModelState.IsValid) 
            {
                return View(departmentCreateDto);
            }

            await _departmentService.CreateAsync(departmentCreateDto);


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            DepartmentGetDto departmentGetDto = await _departmentService.GetById(id);
            DepartmentCreateDto departmentCreateDto = _mapper.Map<DepartmentCreateDto>(departmentGetDto);
            return View(departmentCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentCreateDto departmentCreateDto, int id)
        {
            if (!ModelState.IsValid) 
            {
                return View(departmentCreateDto);
            }

            await _departmentService.Update(departmentCreateDto, id);

            return View();
        }

        public  async Task<IActionResult> Delete(int id) 
        {
           await _departmentService.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
