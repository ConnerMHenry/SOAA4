using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestServices.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace CrazyMelvinsCleint
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            switch ((string)Session["display_type"])
            {
                case "Customer":
                    html = ShowCustomers();
                    break;
                case "Product":
                    html = ShowProducts();
                    break;
                case "Order":
                    html = ShowOrders();
                    break;
                case "Cart":
                    html = ShowCarts();
                    break;
                case "PurchaseOrder":
                    html = ShowPO();
                    break;
            }
            DataContainer.InnerHtml = html;
        }

        private string ShowCustomers()
        {
            List<Customer> custs = JsonConvert.DeserializeObject<List<Customer>>((string)Session["display_data"]);
            string html = "<table><tr><td>CustId</td><td>First Name</td><td>Last Name</td><td>PhoneNumber</td></tr>";
            foreach (Customer cust in custs)
            {
                html += "<tr><td>" + cust.custId + "</td><td>" + cust.firstName + "</td><td>" + cust.lastName + "</td><td>" + cust.phoneNumber + "</td></tr>";
            }
            html += "</table>";
            return html;
        }

        private string ShowProducts()
        {
            List<Product> prods = JsonConvert.DeserializeObject<List<Product>>((string)Session["display_data"]);
            string html = "<table><tr><td>ProdId</td><td>Prod Name</td><td>Price</td><td>Weight</td><td>InStock</td></tr>";
            foreach (Product prod in prods)
            {
                html += "<tr><td>" + prod.prodId + "</td><td>" + prod.prodName + "</td><td>" + prod.price + "</td><td>" + prod.prodWeight + "</td><td>" + (prod.inStock ? "true" : "false") + "</td></tr>";
            }
            html += "</table>";
            return html;
        }

        private string ShowOrders()
        {
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>((string)Session["display_data"]);
            string html = "<table><tr><td>OrderId</td><td>CustId</td><td>poNumber</td><td>PhoneNumber</td></tr>";
            foreach (Order order in orders)
            {
                html += "<tr><td>" + order.orderId + "</td><td>" + order.custId + "</td><td>" + order.poNumber + "</td><td>" + order.orderDate + "</td></tr>";
            }
            html += "</table>";
            return html;
        }

        private string ShowCarts()
        {
            List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>((string)Session["display_data"]);
            string html = "<table><tr><td>OrderId</td><td>ProdId</td><td>Quantity</td></tr>";
            foreach (Cart cart in carts)
            {
                html += "<tr><td>" + cart.orderId + "</td><td>" + cart.prodId + "</td><td>" + cart.quantity + "</td></tr>";
            }
            html += "</table>";
            return html;
        }

        private string ShowPO()
        {
            PurchaseOrder po = JsonConvert.DeserializeObject<PurchaseOrder>((string)Session["display_data"]);
            string html = "<div>CustId:" + po.customer.custId + ", Name:" + po.customer.firstName + " " + po.customer.lastName + "</div>";
            html += "<div>OrderId:" + po.order.orderId + ",POnumber:" + po.order.poNumber + ",Date:" + po.order.orderDate.ToString() + "</div>";

            html += "<table>";
            foreach (Cart cart in po.carts)
            {
                html += "<tr><td>" + po.products[cart.prodId].prodName + "</td><td>" + po.products[cart.prodId].price + "</td><td>" + po.products[cart.prodId].prodWeight + "</td></tr>";
            }
            html += "</table>";
            html += "<div>Pieces:" + po.pieces + ",Weight:" + po.weight + "</div>";
            html += "<div>Subtotal:" + po.subTotal + ", Tax:" + po.tax + ",Total:" + po.total + "</div>";
            return html;
        }
    }
}