using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

using System.Net.Mail;
using System.Text;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddressInformation addressd)
        {
            //SmtpClient client = new SmtpClient();
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new NetworkCredential("visioinventum@gmail.com", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            //string bodytext = "Nova narudžba je zaprimljena! Kupac: " + addressd.FirstName + " " + addressd.LastName + Environment.NewLine;
            //var products = (List<Item>)Session["cart"];
            //decimal total = 0;
            //foreach (var x in products)
            //{
            //    total += (x.Count * x.Product.Price);
            //    bodytext += (x.Product.Name + " " + x.Product.Price + " " + x.Count + Environment.NewLine);
            //}

            //bodytext += Environment.NewLine + "Total sum: " + total;
            //MailMessage mm = new MailMessage("visioinventum@gmail.com", "mario.salai@gmail.com", "Narudzba", bodytext);
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //client.Send(mm);
            return View("OrderCompleted");
        }
    }
}