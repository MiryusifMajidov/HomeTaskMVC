using HospitalMApi.Bl.Implementations.Interfaces;
using HospitalMApi.Model.DTOs.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("getalldata")]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var patients = await _patientService.GetAllAsync();
                return Ok(patients);
            }
            catch
            {
                return BadRequest();
            }
               
        }

        [HttpPost("addnewdata")]
        public async Task<IActionResult> AddNewData(PatientCreateDto patientCreateDto) 
        {
            try
            {
                await _patientService.AddAsync(patientCreateDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
           
        
        }

        [HttpGet("getdata")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _patientService.GetByIdAsync(id);
                return Ok(patient);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(PatientUpdateDto patientUpdateDto,int id)
        {
            try
            {
                patientUpdateDto.Id = id;
                await _patientService.UpdateAsync(patientUpdateDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _patientService.SoftDeleteAsync(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
       
    }
}
