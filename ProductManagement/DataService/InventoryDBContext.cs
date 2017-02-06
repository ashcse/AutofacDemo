using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement
{   
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<ProductManagement.Models.Department> Departments { get; set; }
    }
}