using ProductManagement.DataService;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private IDataService _dataService = null;


        public ApplicationService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dataService.GetAllProducts();
        }

        public Product FindProduct(int id)
        {
            return _dataService.FindProduct(id);
        }

        public int CreateProduct(Product product)
        {
            return _dataService.CreateProduct(product);
        }
        


        public int UpdateProduct(Product product)
        {
            return _dataService.Update(product);
        }

        public int DeleteProduct(int id)
        {
            return _dataService.Delete(id);
        }
    }
}