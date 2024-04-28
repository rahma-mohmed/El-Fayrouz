using Fayroz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fayroz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FayrozDbContext _dbContext;
        User user = new User();
        public HomeController(ILogger<HomeController> logger, FayrozDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Recipe> SpecialItems = _dbContext.Recipes.Where(r => r.isSpecial).ToList();
            List<Recipe> newItems = _dbContext.Recipes
                .Where(r => r.DateTime.AddDays(3) >= DateTime.Now)
                .OrderBy(r => r.Name)
                .Take(6)
                .ToList();

            ViewBag.NewItems = newItems;

            return View(SpecialItems);
        }

        public IActionResult Signup()
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (_dbContext.Users.Any(x => x.Name == user.Name))
                {
                    ViewBag.Notification = "This account has already exists";
                    return View(user);
                }
                else
                {
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();

                    HttpContext.Session.SetString("Id", user.Id.ToString());
                    HttpContext.Session.SetString("Name", user.Name);

                    return RedirectToAction("Index");

                }
            }
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Login()
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var check = _dbContext.Users.Where(x => x.Name.Equals(user.Name) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (check != null)
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("Name", user.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View(user);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}