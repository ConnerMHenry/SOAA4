﻿using System;
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
    public partial class SecondPage : System.Web.UI.Page
    {
        private Option userOption;
        private ExecutionType current_type;
        private List<BaseValidator> validators;

        protected void Page_Load(object sender, EventArgs e)
        {

            validators = new List<BaseValidator>
            {
                CustomerIDValidator,
                CustomerPhoneNumberValidator,
                RegularExpressionValidator3,
                RegularExpressionValidator4,
                RegularExpressionValidator5,
                RegularExpressionValidator6,
                RegularExpressionValidator7,
            };

            try
            {
                string optionStr = Request.QueryString["option"];

                switch (optionStr)
                {
                    case "Delete":
                        userOption = Option.Delete;
                        break;

                    case "Update":
                        userOption = Option.Update;
                        break;

                    case "Insert":
                        userOption = Option.Insert;
                        break;

                    default:
                        userOption = Option.Search;
                        break;
                }
                
            }
            catch
            {
                userOption = Option.Search;
            }
        }

        protected void ExecuteCustomer(object sender, EventArgs e)
        {
            current_type = ExecutionType.Customer;
            ExecuteBtn_Click(sender, e);
        }

        protected void ExecuteProduct(object sender, EventArgs e)
        {
            current_type = ExecutionType.Product;
            ExecuteBtn_Click(sender, e);
        }

        protected void ExecuteOrder(object sender, EventArgs e)
        {
            if (GeneratePoCheckbox.Checked && userOption == Option.Search)
            {
                current_type = ExecutionType.ProductOrder;
            }
            else
            {
                current_type = ExecutionType.Order;
            }
            ExecuteBtn_Click(sender, e);
        }

        protected void ExecuteCart(object sender, EventArgs e)
        {
            current_type = ExecutionType.Cart;
            ExecuteBtn_Click(sender, e);
        }

        protected void ExecuteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if each validator is valid
                bool valid = true;
                if (userOption == Option.Insert || userOption == Option.Update)
                {
                    foreach (BaseValidator validator in validators)
                    {
                        validator.Validate();
                        if (!validator.IsValid)
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                // If not, don't execute the function
                if (!valid)
                {
                    return;
                }
                HttpResponseMessage response = null;

                switch (userOption)
                {
                    case Option.Search:
                        response = Search();
                        break;

                    case Option.Update:
                        response = Update();
                        break;

                    case Option.Delete:
                        response = Delete();
                        break;

                    default:
                        response = Insert();
                        break;
                }
                switch (userOption)
                {
                    case Option.Search:
                        if (response.IsSuccessStatusCode)
                        {
                            Session["display_data"] = response.Content.ReadAsStringAsync().Result;
                            Session["display_type"] = current_type.ToString();
                            Response.Redirect("~/SearchResults.aspx", false);
                            break;
                        }
                        else
                        {
                            AlertBox(response.Content.ReadAsStringAsync().Result);
                            break;
                        }
                        break;
                    default:
                        string content = "";
                        if (response.IsSuccessStatusCode)
                        {
                            content = "Success!";
                        }
                        else
                        {
                            content = response.Content.ReadAsStringAsync().Result;
                            content = content.Replace("\"", "").Replace("\'", "");
                        }
                        
                        AlertBox(content);
                        break;
                }

                
            }
            catch (Exception exc)
            {
                AlertBox("Error:" + exc.Message);
            }
        }

        private HttpResponseMessage Search()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/Search/");
            HttpResponseMessage result = null;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.GetAsync("Customer/" + GetCustomerQuery()).Result;
                    break;
                case ExecutionType.Product:
                    result = http.GetAsync("Product/" + GetProductQuery()).Result;
                    break;
                case ExecutionType.Order:
                    result = http.GetAsync("Order/" + GetOrderQuery()).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.GetAsync("Cart/" + GetcartQuery()).Result;
                    break;
                case ExecutionType.ProductOrder:
                    result = http.GetAsync("PurchaseOrder/" + GetCustomerQuery() + ";" + GetOrderQuery()).Result;
                    break;
            }

            return result;
        }

        private HttpResponseMessage Insert()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result = null;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.PostAsync("Customer/", new StringContent(JsonConvert.SerializeObject(GetEnteredCustomer()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Product:
                    result = http.PostAsync("Product/", new StringContent(JsonConvert.SerializeObject(GetEnteredProduct()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Order:
                    result = http.PostAsync("Order/", new StringContent(JsonConvert.SerializeObject(GetEnteredOrder()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.PostAsync("Cart/", new StringContent(JsonConvert.SerializeObject(GetEnteredCart()), Encoding.UTF8, "application/json")).Result;
                    break;
            }

            return result;
        }

        private HttpResponseMessage Update()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result = null;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.PutAsync("Customer/", new StringContent(JsonConvert.SerializeObject(GetEnteredCustomer()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Product:
                    result = http.PutAsync("Product/", new StringContent(JsonConvert.SerializeObject(GetEnteredProduct()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Order:
                    result = http.PutAsync("Order/", new StringContent(JsonConvert.SerializeObject(GetEnteredOrder()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.PutAsync("Cart/", new StringContent(JsonConvert.SerializeObject(GetEnteredCart()), Encoding.UTF8, "application/json")).Result;
                    break;
            }

            return result;
        }

        private HttpResponseMessage Delete()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result = null;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.DeleteAsync("Customer/" + GetEnteredCustomer().custId).Result;
                    break;
                case ExecutionType.Product:
                    result = http.DeleteAsync("Product/" + GetEnteredProduct().prodId).Result;
                    break;
                case ExecutionType.Order:
                    result = http.DeleteAsync("Order/" + GetEnteredOrder().orderId).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.DeleteAsync("Cart/" + GetEnteredCart().orderId + "/" + GetEnteredCart().prodId).Result;
                    break;
            }

            return result;
        }
        

        private Customer GetEnteredCustomer()
        {
            Customer cust = new Customer();
            if (CustID.Text.ToString().Length > 0)
            {
                cust.custId = Convert.ToInt32(CustID.Text.ToString());
            }

            if (FirstName.Text.ToString().Length > 0)
            {
                cust.firstName = FirstName.Text.ToString();
            }

            if (LastName.Text.ToString().Length > 0)
            {
                cust.lastName = LastName.Text.ToString();
            }

            if (PhoneNumber.Text.ToString().Length > 0)
            {
                cust.phoneNumber = PhoneNumber.Text.ToString();
            }


            return cust;
        }

        private Product GetEnteredProduct()
        {
            Product prod = new Product();
            if (ProdID.Text.ToString().Length > 0)
            {
                prod.prodId = Convert.ToInt32(ProdID.Text.ToString());
            }

            if (ProductName.Text.ToString().Length > 0)
            {
                prod.prodName = ProductName.Text.ToString();
            }

            if (ProdWeight.Text.ToString().Length > 0)
            {
                prod.prodWeight = Convert.ToDecimal(ProdWeight.Text.ToString());
            }

            if (Price.Text.ToString().Length > 0)
            {
                prod.price = Convert.ToDecimal(Price.Text.ToString());
            }
            prod.inStock = InStock.Checked;

            return prod;
        }

        private Order GetEnteredOrder()
        {
            Order ord = new Order();
            if (OrderID.Text.ToString().Length > 0)
            {
                ord.orderId = Convert.ToInt32(OrderID.Text.ToString());
            }

            if (OrderCustID.Text.ToString().Length > 0)
            {
                ord.custId = Convert.ToInt32(OrderCustID.Text.ToString());
            }

            if (OrderDate.Text.ToString().Length > 0)
            {
                ord.orderDate = DateTime.ParseExact(OrderDate.Text.ToString(), "MM-dd-yy", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (PoNumber.Text.ToString().Length > 0)
            {
                ord.poNumber = PoNumber.Text.ToString();
            }
            else
            {
                ord.poNumber = "";
            }

            return ord;
        }
        private Cart GetEnteredCart()
        {
            Cart cart = new Cart();

            if (CartOrderID.Text.ToString().Length > 0)
            {
                cart.orderId = Convert.ToInt32(CartOrderID.Text.ToString());
            }

            if (CartProductID.Text.ToString().Length > 0)
            {
                cart.prodId = Convert.ToInt32(CartProductID.Text.ToString());
            }

            if (Quantity.Text.ToString().Length > 0)
            {
                cart.quantity = Convert.ToInt32(Quantity.Text.ToString());
            }

            return cart;
        }

        private string GetCustomerQuery()
        {
            string query = "";
            if (CustID.Text.ToString().Length > 0)
            {
                query += "custId=" + CustID.Text.ToString() + ";";
            }

            if (FirstName.Text.ToString().Length > 0)
            {
                query += "firstName=" + FirstName.Text.ToString() + ";";
            }

            if (LastName.Text.ToString().Length > 0)
            {
                query += "lastName=" + LastName.Text.ToString() + ";";
            }

            if (PhoneNumber.Text.ToString().Length > 0)
            {
                query += "phoneNumber" + PhoneNumber.Text.ToString();
            }


            return query;
        }

        private string GetProductQuery()
        {
            string query = "";
            if (ProdID.Text.ToString().Length > 0)
            {
                query += "prodId=" + ProdID.Text.ToString() + ";";
            }

            if (ProductName.Text.ToString().Length > 0)
            {
                query += "prodName=" + ProductName.Text.ToString() + ";";
            }

            if (ProdWeight.Text.ToString().Length > 0)
            {
                query += "prodWeight=" + ProdWeight.Text.ToString() + ";";
            }

            if (Price.Text.ToString().Length > 0)
            {
                query += "price=" + Price.Text.ToString() + ";";
            }

            return query;
        }

        private string GetOrderQuery()
        {
            string query = "";
            if (OrderID.Text.ToString().Length > 0)
            {
                query += "orderId=" + OrderID.Text.ToString() + ";";
            }

            if (OrderCustID.Text.ToString().Length > 0)
            {
                query += "custId=" + OrderCustID.Text.ToString() + ";";
            }

            if (OrderDate.Text.ToString().Length > 0)
            {
                query += "orderDate=" + DateTime.ParseExact(OrderDate.Text.ToString(), "MM-dd-yy", System.Globalization.CultureInfo.InvariantCulture).ToString() + ";";
            }

            if (PoNumber.Text.ToString().Length > 0)
            {
                query += "poNumber=" + PoNumber.Text.ToString();
            }

            return query;
        }
        private string GetcartQuery()
        {
            string query = "";

            if (CartOrderID.Text.ToString().Length > 0)
            {
                query += "orderId=" + CartOrderID.Text.ToString() + ";";
            }

            if (CartProductID.Text.ToString().Length > 0)
            {
                query += "prodId=" + CartProductID.Text.ToString() + ";";
            }

            if (Quantity.Text.ToString().Length > 0)
            {
                query += "quantity=" + Quantity.Text.ToString() + ";";
            }

            return query;
        }

        // https://www.aspsnippets.com/Articles/Show-Alert-Message-in-ASPNet-from-Server-Side-using-C-and-VBNet.aspx
        protected void AlertBox(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}