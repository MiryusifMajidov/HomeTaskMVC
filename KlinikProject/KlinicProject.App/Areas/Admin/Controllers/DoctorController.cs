using AutoMapper;
using KlinicProject.BL.Implementations.Interfaces;
using KlinicProject.BL.Implementations.Services;
using KlinicProject.Model.Dtos.DoctorDtos;
using Microsoft.AspNetCore.Mvc;

namespace KlinicProject.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
           
           IEnumerable<DoctorGetDto> doctors = await _doctorService.GetAllAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Departaments = await _departmentService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateDto dto) 
        {
            if (!ModelState.IsValid || dto.ImageUrl == null)
            {
                return View(dto);
                
            }

            await _doctorService.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Departaments = await _departmentService.GetAllAsync();
            DoctorGetDto doctorGetDto = await _doctorService.GetById(id);
            DoctorCreateDto doctorCreateDto = _mapper.Map<DoctorCreateDto>(doctorGetDto);
            return View(doctorCreateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DoctorCreateDto doctorCreateDto, int Id)
        {
            if (ModelState.IsValid) 
            {
                return View(doctorCreateDto);
            }
            await _doctorService.Update(doctorCreateDto, Id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
