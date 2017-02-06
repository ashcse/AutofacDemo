using ProductManagement.ApplicationService;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : BaseController
    {
        private IApplicationService _applicationService = null;


        public ProductController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }        

        // GET: Product
        public ActionResult Index()
        {
            var products = _applicationService.GetAllProducts();
            throw new NotImplementedException();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product prod = _applicationService.FindProduct(id);
            return View(prod);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            try
            {
                _applicationService.CreateProduct(prod);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = _applicationService.FindProduct(id);
            return View(p);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                _applicationService.UpdateProduct(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _applicationService.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
