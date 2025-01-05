using FinalApi.BL.Implementations.Interfaces;
using FinalApi.BL.Implementations.Services;
using FinalApi.Model.DTOs.User;
using FinalApi.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IEmailSender _emailSender;
        private readonly JwtService _jwtService;

        public AccountController(IRegisterService registerService, UserManager<AppUser> userManager, IEmailSender emailSender, JwtService jwtService, SignInManager<AppUser> signInManager)
        {
            _registerService = registerService;
            _userManager = userManager;
            _emailSender = emailSender;
            _jwtService = jwtService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto userDto)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

           var user = await _registerService.RegisterAsync(userDto);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Email Confirmation",
                $"<h1>Confirm your email</h1><p>Please <a href='{confirmationLink}'>click here</a> to confirm your email.</p>");

            return Ok("Registration successful. Please confirm your email.");
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password.");
            }

            var roles = await _userManager.GetRolesAsync(user);



            var token = _jwtService.GenerateToken(user, roles);
            return Ok(new { Token = token });
        }


       /* public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { Message = "Logged out successfully." });
        }*/




        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid email confirmation request.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Email successfully confirmed.");
            }

            return BadRequest("Email confirmation failed.");
        }


    }
}
