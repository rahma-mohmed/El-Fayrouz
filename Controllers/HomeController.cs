using Fayroz.ContextDbConfig;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}