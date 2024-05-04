using Fayroz.ContextDbConfig;
using Fayroz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.Controllers
{
    public class AccountController : Controller
    {
        private readonly FayrozDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(FayrozDbContext fayrozDbContext, SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _dbContext = fayrozDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region LogIn
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult?> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(login);
        }
        #endregion

        #region LogOut
        public async Task<IActionResult?> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            var Address = _dbContext.Addresses
                .OrderBy(a=> a.CityName)
                .Select(a => new SelectListItem {Value = a.Id.ToString(),Text =a.CityName})
                .AsNoTracking()
                .ToList();
            ViewBag.Addresses = Address;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            ModelState.Remove("Address");
            if(ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = register.Name,
                    Email = register.Email,
                    Address = _dbContext.Addresses.Find(register.AddressId).CityName,
                    UserName = register.Name,
                };
                var result =await _userManager.CreateAsync(user,register.Password);
                if (result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(user, register.Password, false, false);
                    return RedirectToAction("Index","Home");
                }
            }
            var Address = _dbContext.Addresses
                .OrderBy(a => a.CityName)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.CityName })
                .AsNoTracking()
                .ToList();
            ViewBag.Addresses = Address;
            return View(register);
        }
        #endregion 
    }
}
