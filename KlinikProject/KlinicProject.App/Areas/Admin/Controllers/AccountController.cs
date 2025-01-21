using KlinicProject.Model.Dtos.AppUserDtos;
using KlinicProject.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KlinicProject.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
     


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
           
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto userDto)
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
                UserName = userDto.FirstName+userDto.LastName,
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

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            await _userManager.AddToRoleAsync(user, "User");



            return RedirectToAction(nameof(Index), "Dashboard");
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }


            var user =  await _userManager.FindByNameAsync(userDto.UserName);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User or password not found");
                return View(userDto);
            }



            var roles = await _userManager.GetRolesAsync(user);
          /*  if (!roles.Contains("Admin"))
            {
                ModelState.AddModelError(string.Empty, "You do not have the required role.");
                return View(userDto);
            }*/


            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.isPersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(userDto);
            }

            return RedirectToAction(nameof(Index), "DashBoard");
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "DashBoard");
        }
    }
}
