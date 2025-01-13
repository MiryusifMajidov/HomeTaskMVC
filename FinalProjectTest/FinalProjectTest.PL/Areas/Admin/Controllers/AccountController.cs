using FinalProjectTest.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProjectTest.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
/*
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            AppUser user = new AppUser
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Username,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(userDto);
            }

            await _userManager.AddToRoleAsync(user, "User");


            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account",
                new { userId = user.Id, token = token }, Request.Scheme);


            await _emailSender.SendEmailAsync(user.Email, "Email Təsdiqləmə",
                $"<h1>Emailinizi təsdiqləyin</h1><p>Zəhmət olmasa <a href='{confirmationLink}'>buraya klikləyin</a> emailinizi təsdiqləmək üçün.</p>");

            return RedirectToAction(nameof(Index), "Home");
        }
*/


        public IActionResult Login()
        {
            return View();
        }

      /*  [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }


            var user = await _userManager.FindByEmailAsync(userDto.UsernameOrEmail)
                        ?? await _userManager.FindByNameAsync(userDto.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User or password not found");
                return View(userDto);
            }


            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Your email is not confirmed. Please check your inbox.");
                return View(userDto);
            }


            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                ModelState.AddModelError(string.Empty, "You do not have the required role.");
                return View(userDto);
            }


            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.isPersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(userDto);
            }

            return RedirectToAction(nameof(Index), "Home");
        }*/


      /*  public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }*/




    }
}
