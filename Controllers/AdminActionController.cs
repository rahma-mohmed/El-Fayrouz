using Fayroz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.Controllers
{
    public class AdminActionController : Controller
    {
        private readonly FayrozDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminActionController(FayrozDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;

        }

        #region Index & Search
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
        #endregion

        #region Create
        public IActionResult Add()
        {
            Recipe recipe = new Recipe();
            List<SelectListItem> categories = _dbContext.Categories
                .OrderBy(r => r.Name)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .AsNoTracking()
                .ToList();
            ViewBag .Categories = categories;
            return View(recipe);
        }
        [HttpPost]
        public IActionResult Add(Recipe recipe, IFormFile imageFile)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _dbContext.Recipes.Add(recipe);
                _dbContext.SaveChanges();
                if (imageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = $"{recipe.Id}{Path.GetExtension(imageFile.FileName)}";
                    string filePath = Path.Combine(wwwRootPath, "images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    recipe.Image = fileName;
                    _dbContext.SaveChanges(); 
                }

                return RedirectToAction("Index"); 
            }
            List<SelectListItem> categories = _dbContext.Categories
                .OrderBy(r => r.Name)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .AsNoTracking()
                .ToList();
            ViewBag.Categories = categories;

            return View(recipe);
        }
        #endregion

        #region Update
        public IActionResult Edit()
        {
            return View();
        }
        #endregion
    }
}