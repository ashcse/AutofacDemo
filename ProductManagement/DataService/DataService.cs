using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.DataService
{
    public class DataService : IDataService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (ProductDbContext _db = new ProductDbContext())
            {
                try
                {
                    var result = _db.Products;
                    return result.ToList<Product>();

                }catch(Exception exc)
                {

                }
            }

            return null;               
        }

        public Product FindProduct(int id)
        {
            using (ProductDbContext _db = new ProductDbContext())
            {
                Product p = _db.Products.Find(id);
                return p;
            }
        }

        public int CreateProduct(Product product)
        {
            using (ProductDbContext _db = new ProductDbContext())
            {
                _db.Products.Add(product);
                return _db.SaveChanges();
            }           
        }

        public int Update(Product product)
        {
            using (ProductDbContext _db = new ProductDbContext())
            {
                Product p =_db.Products.First( e => e.ID == product.ID);

                p.Name = product.Name;
                p.Price = product.Price;
                p.Description = product.Description;
                _db.Entry<Product>(p).State = System.Data.Entity.EntityState.Modified;
                return _db.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (ProductDbContext _db = new ProductDbContext())
            {
                Product p = _db.Products.First(e => e.ID == id);
                _db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                return _db.SaveChanges();
            }
        }
    }
}