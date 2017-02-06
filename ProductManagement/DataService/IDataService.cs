using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataService
{
    public interface IDataService
    {
        IEnumerable<Product> GetAllProducts();

        Product FindProduct(int id);

        int CreateProduct(Product product);

        int Update(Product product);

        int Delete(int id);
    }
}
