using Fayroz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.Controllers
{
    public class MenuController : Controller
    {
        private readonly FayrozDbContext _dbContext;

        public MenuController(FayrozDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IActionResult Index()
        {
            var recipes = _dbContext.Recipes.ToList();
            ViewBag.Recipe = recipes;
            List<Category> Categories = _dbContext.Categories.ToList();
            ViewBag.Categories = Categories;
            return View();
        }
    }
}
