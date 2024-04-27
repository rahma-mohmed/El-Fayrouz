using Microsoft.AspNetCore.Mvc;
using Fayroz.Models;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.Controllers
{
    public class RecipeController : Controller
    {

        private FayrozDbContext _dbContext;
        public RecipeController(FayrozDbContext dbContext)
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

        public IActionResult Order(int id) {
            Recipe order = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
            List<Category> Categories = _dbContext.Categories.ToList();
            ViewBag.Categories = Categories;
            return View(order);
        }
    }
}