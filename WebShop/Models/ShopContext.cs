using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<WebShop.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<WebShop.Models.AddressInformation> AddressInformations { get; set; }
    }
}