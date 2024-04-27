using Fayroz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.Controllers
{
    public class AdminActionController : Controller
    {
        private readonly FayrozDbContext _dbContext;
        public AdminActionController(FayrozDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var recipesByCategory = _dbContext.Recipes
                .Include(r => r.Category)
                .AsEnumerable()
                .GroupBy(r => r.Category)
                .ToList();
            List<Category> Categories = _dbContext.Categories.ToList();
            ViewBag.Categories = Categories;

            var AllRecipes = _dbContext.Recipes.ToArray();
            ViewBag.AllRecipes = AllRecipes;
            return View(recipesByCategory);
        }

        public IActionResult Search(string recipe)
        {
            var recipes = _dbContext.Recipes.Where(r => r.Name.Contains(recipe)).ToList();
            ViewBag.Recipe = recipes;
            List<Category> Categories = _dbContext.Categories.ToList();
            ViewBag.Categories = Categories;
            return View();
        }
    }
}