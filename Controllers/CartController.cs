using Fayroz.ContextDbConfig;
using Fayroz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace Fayroz.Controllers
{
    public class CartController : Controller
    {
        private readonly FayrozDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public CartController(FayrozDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartsList = _dbContext.Carts.Where(c => c.UserId == user.Id).ToList();

            return View(cartsList);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCart(int id)
        {
            Recipe recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
            var user = await _userManager.GetUserAsync(User);

            var existingCartItem = _dbContext.Carts.FirstOrDefault(x => x.RecipeId == id && x.UserId == user.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Name = recipe.Name;
                existingCartItem.Description = recipe.Description;
                existingCartItem.Image = recipe.Image;
            }
            else
            {
                Cart cart = new Cart
                {
                    UserId = user.Id,
                    RecipeId = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Image = recipe.Image
                };

                _dbContext.Carts.Add(cart);
            }

            _dbContext.SaveChanges();
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> RemoveCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var c = _dbContext.Carts.FirstOrDefault(x => x.RecipeId == id && x.UserId == user.Id);

            _dbContext.Carts.Remove(c);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartList = _dbContext.Carts.Where(c => c.UserId == user.Id).Take(3).ToList();
            return PartialView("_GetCart", cartList);
        }

        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var c = _dbContext.Carts.FirstOrDefault(x => x.Id == id && x.UserId == user.Id);
            _dbContext.Carts.Remove(c);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}