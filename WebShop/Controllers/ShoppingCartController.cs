using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View("Cart");
        }

        private int CheckIfExists(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ID == id)
                {
                    return i;
                }
            }
            return -1;  //ovako ću znati da ga nema
        }

        public ActionResult AddToCart(int ProductId)
        {
            ShopContext db = new ShopContext();
            var product = db.Products.Single(p => p.ID == ProductId);
            if (Session["cart"] == null) //budući da je null, onda košarica ne postoji
            {
                List<Item> cart = new List<Item>();
                Item item = new Item();
                item.Product = product;
                item.Count = 1;
                cart.Add(item);
                Session["cart"] = cart;
            }
            else  //košarica postoji
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int location = CheckIfExists(ProductId);
                if (location == -1)  //dodani proizvod nije bio u košarici
                {
                    Item item = new Item(); //pa ga moramo dodati
                    item.Product = product;
                    item.Count = 1;
                    cart.Add(item);
                }
                else  //dodani proizvod je bio u košarici na lokaciji "location"
                {
                    cart[location].Count++;
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int ProductId)
        {
            List<Item> cart = (List<Item>)Session["cart"];  //dohvatimo listu iz sessiona
            int location = CheckIfExists(ProductId);//pronađemo na kojoj lokaciji je taj proizvod
            cart.RemoveAt(location); //uklonimo taj proizvod sa liste
            Session["cart"] = cart;  //listu ponovno pohranimo u session

            return RedirectToAction("Index"); //ponovno prikažemo tablicu proizvoda u košarici
        }

        public ActionResult IncreaseCount(int ProductId)
        {
            List<Item> cart = (List<Item>)Session["cart"];  //dohvatimo listu iz sessiona
            int location = CheckIfExists(ProductId);//pronađemo na kojoj lokaciji je taj proizvod
            cart[location].Count++;
            Session["cart"] = cart;  //listu ponovno pohranimo u session
            return RedirectToAction("Index");
        }

        public ActionResult DecreaseCount(int ProductId)
        {
            List<Item> cart = (List<Item>)Session["cart"];  //dohvatimo listu iz sessiona
            int location = CheckIfExists(ProductId);//pronađemo na kojoj lokaciji je taj proizvod
            if (cart[location].Count == 1)
            {
                cart.RemoveAt(location);
            }
            else
            {
                cart[location].Count--;
            }
            
            Session["cart"] = cart;  //listu ponovno pohranimo u session
            return RedirectToAction("Index");
        }
    }
}