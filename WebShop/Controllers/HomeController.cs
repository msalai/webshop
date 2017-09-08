using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetCategories()
        {
            ShopContext db = new ShopContext();
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult Products(int cigla)
        {
            ShopContext db = new ShopContext();
            var products = db.Products.Where(p => p.CategoryId == cigla).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            ShopContext db = new ShopContext();
            var product = db.Products.Single(p => p.ID == id);
            return View(product);
        }
    }
}