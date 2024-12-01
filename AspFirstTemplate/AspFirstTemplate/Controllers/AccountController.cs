using AspFirstTemplate.Data;
using AspFirstTemplate.DTOs.UserDTOs;
using AspFirstTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        //public AccountController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = appDbContext;
             _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Register(CreateUserDto UserDto)
        {
           

            AppUser user = new AppUser();

            user.FirstName = UserDto.FirstName;
            user.LastName = UserDto.LastName;
            user.Email = UserDto.Email;
            user.UserName = UserDto.Username;

            var result = await _userManager.CreateAsync(user, UserDto.Password);

            if (!result.Succeeded) {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

                return View(UserDto);

            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Login() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {

            if (!ModelState.IsValid)
            {
                
                return View(loginUserDto);
            }

            AppUser? appUser = _context.AppUsers.FirstOrDefault(x=>x.UserName == loginUserDto.UsernameOrEmail || x.Email == loginUserDto.UsernameOrEmail);

            if (appUser == null) 
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(loginUserDto);
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, loginUserDto.Password, loginUserDto.isPersistant, true);
            if (!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(loginUserDto);
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Logout() 
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
