using MediClub.BL.Services.Interfaces;
using MediClubModel.DTOs;
using MediClubModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediClub.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IService<Patient> _service;

        public PatientController(IService<Patient> service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var patients = await _service.GetAllAsync();
            return View(patients);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(patientDto);
            }

            Patient patient = new Patient
            {
                Name = patientDto.Name,
                Surname = patientDto.Surname,
                Finkod = patientDto.Finkod,
                PhoneNumber = patientDto.PhoneNumber,
                Username = patientDto.Name + patientDto.Finkod,
                IsDeleted = false
            };

            await _service.AddAsync(patient);

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Update(int id)
        {
            Patient patient = await _service.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            PatientDto patientDto = new PatientDto
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Finkod = patient.Finkod,
                PhoneNumber = patient.PhoneNumber
            };

            return View(nameof(Create), patientDto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Update(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(patientDto);
            }

            Patient patient = new Patient
            {
                Name = patientDto.Name,
                Surname = patientDto.Surname,
                Finkod = patientDto.Finkod,
                PhoneNumber = patientDto.PhoneNumber,
                Username = patientDto.Name + patientDto.Finkod,
                IsDeleted = false,
                UpdatedAt = DateTime.Now,
                
            };

            await _service.UpdateAsync(patient);

            return RedirectToAction(nameof(Index));
        }


  
        public async Task<IActionResult> Delete(int id)
        {
            Patient patient = await _service.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _service.HardDeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

       
        
    }
}
