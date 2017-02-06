using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ApplicationService
{
    public interface IApplicationService
    {
        IEnumerable<Product> GetAllProducts();

        Product FindProduct(int id);

        int CreateProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProduct(int id);
    }
}
