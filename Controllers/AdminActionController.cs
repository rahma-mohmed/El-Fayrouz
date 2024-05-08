using Fayroz.ContextDbConfig;
using Fayroz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
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
            return View(recipesByCategory);
        }


        public IActionResult Search_Menu(string category)
        {
            var recipes = _dbContext.Recipes.Where(r => r.Category.Name.Contains(category)).ToList();
            ViewBag.Recipe = recipes;
            List<Category> Categories = _dbContext.Categories.ToList();
            ViewBag.Categories = Categories;
            return View("Search");
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
                .Select(c => new SelectListItem {Value = c.Id.ToString(),Text = c.Name})
                .AsNoTracking()
                .ToList();
            ViewBag.Categories = categories;
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
        public IActionResult Edit(int id)
        {
            Recipe recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            List<SelectListItem> categories = _dbContext.Categories
                .OrderBy(r => r.Name)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .AsNoTracking()
                .ToList();
            ViewBag.Categories = categories;
            return View(recipe);
        }
        [HttpPost]
        public IActionResult Edit(Recipe recipe, IFormFile imageFile)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                var existingRecipe = _dbContext.Recipes.Find(recipe.Id);
                if (existingRecipe == null)
                {
                    return NotFound();
                }
                if (imageFile != null)
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existingRecipe.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = $"{recipe.Id}{Path.GetExtension(imageFile.FileName)}";
                    string filePath = Path.Combine(wwwRootPath, "images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    recipe.Image = fileName;
                }
                existingRecipe.Name = recipe.Name;
                existingRecipe.Description = recipe.Description;
                existingRecipe.CategoryId = recipe.CategoryId;
                _dbContext.SaveChanges();
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

        #region Delete
        public IActionResult Delete(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            _dbContext.Recipes.Remove(recipe);
            var effectedRows = _dbContext.SaveChanges();
            if (effectedRows > 0)
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", recipe.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            var recipesByCategory = _dbContext.Recipes
                .Include(r => r.Category)
                .AsEnumerable()
                .GroupBy(r => r.Category)
                .ToList();

            List<Category> categories = _dbContext.Categories.ToList();
            ViewBag.Categories = categories;

            return View("Index", recipesByCategory);
        }

        #endregion
    }
}