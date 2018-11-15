using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JacobClient.Models;

namespace JacobClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTestProduct()
        {
            Product product = new Product
            {
                Id = 123,
                Name = "Water balloon",
                Price = 1.25f,
                Weight = 2f,
                IsInStock = true,
                IsControlEnabled = false // use this field when doing SELECTS
            };
            return PartialView("_CardViewProduct", product);
        }

        [HttpGet]
        public ActionResult GetTestOrder()
        {
            Order order = new Order
            {
                CustomerId = 1,
                Id = 54,
                OrderDate = DateTime.Now,
                PONumber = "ABC123"
            };
            return PartialView("_CardViewOrder", order);
        }

        

        [HttpGet]
        public ActionResult GetTestCart()
        {
            Cart cart = new Cart
            {
                OrderId = 54,
                ProductId = 12,
                Quantity = 2
            };
            return PartialView("_CardViewCart", cart);
        }
    }
}