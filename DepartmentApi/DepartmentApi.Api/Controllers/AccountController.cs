using DepartmentApi.BL.Interfaces;
using DepartmentApi.Model.DTOs.Account;
using DepartmentApi.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DepartmentApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreate userDto)
        {
            if (!ModelState.IsValid || userDto.Password != userDto.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password do not match");
            }

            AppUser user = new AppUser
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Username,
                PhoneNumber = userDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Email Confirmation",
                $"<h1>Confirm your email</h1><p>Please <a href='{confirmationLink}'>click here</a> to confirm your email.</p>");

            return Ok("Registration successful. Please confirm your email.");
        }



        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userEmail = User.Identity?.Name;
            if (userEmail == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.RefreshSignInAsync(user);

            return Ok("Password changed successfully.");
        }





        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(userDto.UsernameOrEmail)
                        ?? await _userManager.FindByNameAsync(userDto.UsernameOrEmail);

            if (user == null)
            {
                return Unauthorized("User or password is incorrect.");
            }

            if (!user.EmailConfirmed)
            {
                return BadRequest("Your email is not confirmed. Please check your inbox.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                return Forbid("You do not have the required role.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.isPersistant, true);

            if (!result.Succeeded)
            {
                return Unauthorized("Username or Password is incorrect.");
            }

            return Ok("Login successful.");
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Successfully logged out.");
        }


        
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
