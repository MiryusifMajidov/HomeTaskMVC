using MediClub.BL.Services.Interfaces;
using MediClubModel.DTOs;
using MediClubModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediClub.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
	{
        private readonly IService<Appointment> _service;
        private readonly IService<Doctor> _doctorService;
        private readonly IService<Patient> _patientService;

        public AppointmentController(IService<Appointment> service,IService<Doctor> doctorService,IService<Patient> patientService)
        {
            _service = service;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            
            var appointments = await _service.GetAllAsync();
            return View(appointments);
        }



        public async Task<IActionResult> Create()
        {
            ViewBag.Doctor = await _doctorService.GetAllAsync();
            ViewBag.Patient = await _patientService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(appointmentDto);
            }

           
            if (appointmentDto.AppointmentDate <= DateTime.Now)
            {
                ViewBag.Doctor = await _doctorService.GetAllAsync();
                ViewBag.Patient = await _patientService.GetAllAsync();
                ModelState.AddModelError("AppointmentDate", "Appointment date must be in the future.");
                return View(appointmentDto);
            }

            Appointment appointment = new Appointment
            {
                DoctorId = appointmentDto.DoctorId,
                PatientId = appointmentDto.PatientId,
                AppointmentDate = appointmentDto.AppointmentDate,
                CreatedAt = DateTime.Now,
            };

            await _service.AddAsync(appointment);

            return RedirectToAction(nameof(Index));
        }


    }
}
