using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private CrudDbContext _dbContext;
        public CartController()
        {
            _dbContext = new CrudDbContext();
        }
        public ActionResult Index()
        {
            
            return View(_dbContext.Cart.Include("ItemInCart").ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Cart.Remove(_dbContext.Cart.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}