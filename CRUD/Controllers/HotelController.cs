using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        private CrudDbContext _dbContext;
        public HotelController()
        {
            _dbContext = new CrudDbContext();
        }
        public ActionResult Index(bool isAdmin = false)
        {
            ViewBag.IsAdmin = isAdmin;
            List<FoodItem> foodItem = _dbContext.FoodItems.Include("Category").ToList();

            return View(foodItem);
        }
        public ActionResult Add()
        {
            ViewBag.FormType = "Add";
            FoodCategoryViewModel viewModel = new FoodCategoryViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Add(FoodItem foodItem)
        {
            if (foodItem.Id == 0)
            {
                _dbContext.FoodItems.Add(foodItem);
            }
            else
            {
                FoodItem foodItemInDb = _dbContext.FoodItems.SingleOrDefault(f => f.Id == foodItem.Id);
                foodItemInDb.Name = foodItem.Name;
                foodItemInDb.Price = foodItem.Price;
                foodItemInDb.CategoryId = foodItem.CategoryId;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index",new { isAdmin = true});
        }

        
        public ActionResult Edit(int id)
        {
            ViewBag.FormType = "Edit";
            FoodCategoryViewModel viewModel = new FoodCategoryViewModel
            {
                FoodItem = _dbContext.FoodItems.SingleOrDefault(f => f.Id == id),
                Categories = _dbContext.Categories.ToList()
            };
            return View("Add", viewModel);
        }
        public ActionResult Delete(int id)
        {
            _dbContext.FoodItems.Remove(_dbContext.FoodItems.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index", new { isAdmin = true });
        }

        public ActionResult Cart(int id)
        {
            FoodItem foodItem = _dbContext.FoodItems.SingleOrDefault(f => f.Id == id);
            Cart cart = new Cart()
            {
                ItemInCart = foodItem
            };
            _dbContext.Cart.Add(cart);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
    }
}