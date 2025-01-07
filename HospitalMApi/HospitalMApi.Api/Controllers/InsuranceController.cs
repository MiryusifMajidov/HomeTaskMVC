using HospitalMApi.Bl.Implementations.Interfaces;
using HospitalMApi.Model.DTOs.Insurance;
using HospitalMApi.Model.DTOs.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _InsuranceService;

        public InsuranceController(IInsuranceService InsuranceService)
        {
            _InsuranceService = InsuranceService;
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var patients = await _InsuranceService.GetAllAsync();
                return Ok(patients);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpPost("AddNewData")]
        public async Task<IActionResult> AddNewData(InsuranceCreateDto patientCreateDto)
        {
            try
            {
                await _InsuranceService.AddAsync(patientCreateDto);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            
            }
           

        }

        [HttpGet("GetData")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _InsuranceService.GetByIdAsync(id);
                return Ok(patient);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(InsuranceUpdateDto InsuranceUpdateDto, int id)
        {
            try
            {
                InsuranceUpdateDto.Id = id;
                await _InsuranceService.UpdateAsync(InsuranceUpdateDto);
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
                await _InsuranceService.SoftDeleteAsync(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }

    }
}
