using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JacobClient.Models;

namespace JacobClient.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                var products = new List<Product>();
                products.Add(new Product
                {
                    Id = 1,
                    Name = "Test p1",
                    Price = 2.56f,
                    Weight = 3,
                    IsInStock = true
                });
                products.Add(new Product
                {
                    Id = 2,
                    Name = "Test p2",
                    Price = 5.56f,
                    Weight = 7,
                    IsInStock = true
                });
                products.Add(new Product
                {
                    Id = 3,
                    Name = "Test p3",
                    Price = 0.56f,
                    Weight = 1,
                    IsInStock = true
                });
                return PartialView("_ProductList", new ProductCollection { Products = products });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult InsertUpdate(Product product)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                return Json(new { success = true, responseText = "Success!" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, responseText = "Failure!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}