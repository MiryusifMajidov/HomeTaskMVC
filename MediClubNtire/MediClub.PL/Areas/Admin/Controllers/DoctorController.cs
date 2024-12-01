using MediClub.BL.Services.Interfaces;
using MediClubModel.DTOs;
using MediClubModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MediClub.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
	{

		private readonly IService<Doctor> _service;

        public DoctorController(IService<Doctor> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _service.GetAllAsync(); 
            return View(doctors); 
        }



        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(DoctorDto doctorDto)
		{
            if (!ModelState.IsValid)
            {
				return View(doctorDto);
            }


			Doctor doctor = new Doctor
			{
				Name = doctorDto.Name,
				Surname = doctorDto.Surname,
				Finkod = doctorDto.Finkod,
				PhoneNumber = doctorDto.PhoneNumber,
				Email = doctorDto.Email,
				Username = doctorDto.Name + doctorDto.Finkod,
				IsActive = true
			
			};

			await _service.AddAsync(doctor);

            return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id) 
		{
			Doctor doctor = await _service.GetByIdAsync(id);
            if (doctor == null)
            {
               
                return NotFound(); 
            }

			DoctorDto doctorDto = new DoctorDto
			{
				Name = doctor.Name,
				Surname = doctor.Surname,
				Finkod = doctor.Finkod,
				PhoneNumber = doctor.PhoneNumber,
				Email = doctor.Email,

			};


            return View(nameof(Create), doctorDto);
		}



		[HttpPost]

		public async Task<IActionResult> Update(DoctorDto doctorDto)
		{
			if (!ModelState.IsValid) 
			{
				return View(doctorDto);
			}

			Doctor doctor = new Doctor
			{
				Name = doctorDto.Name,
				Surname = doctorDto.Surname,
				Finkod = doctorDto.Finkod,
				PhoneNumber = doctorDto.PhoneNumber,
				Email = doctorDto.Email,
				UpdatedAt = DateTime.Now,
                Username = doctorDto.Name + doctorDto.Finkod,
                IsActive = true,

            };

			await _service.UpdateAsync(doctor);

			return RedirectToAction(nameof(Index));
		}
	}
}
