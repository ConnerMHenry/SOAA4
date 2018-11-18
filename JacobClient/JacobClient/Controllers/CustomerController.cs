using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JacobClient.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace JacobClient.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Customer customer)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBlankCustomer()
        {
            return PartialView("_CardViewCustomer", new Customer());
        }

        [HttpPost]
        public ActionResult Insert(Customer customer)
        {
            try
            {
				HttpClient http = new HttpClient();
				http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
				HttpResponseMessage result = http.PostAsync("Customer/add", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            try
            {
				HttpClient http = new HttpClient();
				http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
				HttpResponseMessage result = http.PutAsync("Customer/add", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")).Result;


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
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
