using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using PagedList;
using PagedList.Mvc;

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

        public ActionResult Products(int cigla, string SearchText, int? page, string sortOrder)
        {
            ShopContext db = new ShopContext();
            var products = db.Products.Where(p => p.CategoryId == cigla).ToList();

            //#region search
            //if (string.IsNullOrEmpty(SearchText) == false)
            //{
            //    products = products.Where(x => x.Name.Contains(SearchText)).ToList();
            //}
            //ViewBag.search = SearchText;
            //#endregion

            //#region sort
            ////ViewBag.sort = sortOrder == "Price" ? "PriceDesc" : "Price";
            //ViewBag.sort = sortOrder;
            //if (ViewBag.sort == null) ViewBag.sort = "Price";

            //switch (sortOrder)
            //{
            //    case "Price":
            //        products = products.OrderBy(x => x.Price).ToList();
            //        break;
            //    case "PriceDesc":
            //        products = products.OrderByDescending(x => x.Price).ToList();
            //        break;
            //    default:
            //        products = products.OrderBy(x => x.Price).ToList();
            //        break;
            //}
            //#endregion
            //return View(products.ToPagedList(page ?? 1, 6));
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