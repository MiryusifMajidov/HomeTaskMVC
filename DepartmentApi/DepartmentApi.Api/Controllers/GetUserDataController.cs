using DepartmentApi.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserDataController : ControllerBase
    {
        private readonly IUserService userService;

        public GetUserDataController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllData()
        {
            var users = await userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userService.GetById(id);
            return Ok(user);
        }
    }
}
