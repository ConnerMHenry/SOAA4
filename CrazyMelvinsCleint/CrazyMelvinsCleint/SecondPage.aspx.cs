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

            switch (userOption)
            {
                case Option.Search:
                    Search();
                    break;

                case Option.Update:
                    Update();
                    break;

                case Option.Delete:
                    Delete();
                    break;

                default:
                    Insert();
                    break;
            }
        }

        private void Search()
        {
            switch (current_type)
            {
                case ExecutionType.Customer:

                    break;
                case ExecutionType.Product:

                    break;
                case ExecutionType.Order:

                    break;
                case ExecutionType.Cart:

                    break;
                case ExecutionType.ProductOrder:

                    break;
            }
        }

        private void Insert()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.PostAsync("Customer/", new StringContent(JsonConvert.SerializeObject(GetEnteredCustomer()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Product:
                    result = http.PostAsync("Product/", new StringContent(JsonConvert.SerializeObject(GetEneteredProduct()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Order:
                    result = http.PostAsync("Order/", new StringContent(JsonConvert.SerializeObject(GetEnteredOrder()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.PostAsync("Cart/", new StringContent(JsonConvert.SerializeObject(GetEnteredCart()), Encoding.UTF8, "application/json")).Result;
                    break;
            }
        }

        private void Update()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.PutAsync("Customer/", new StringContent(JsonConvert.SerializeObject(GetEnteredCustomer()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Product:
                    result = http.PutAsync("Product/", new StringContent(JsonConvert.SerializeObject(GetEneteredProduct()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Order:
                    result = http.PutAsync("Order/", new StringContent(JsonConvert.SerializeObject(GetEnteredOrder()), Encoding.UTF8, "application/json")).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.PutAsync("Cart/", new StringContent(JsonConvert.SerializeObject(GetEnteredCart()), Encoding.UTF8, "application/json")).Result;
                    break;
            }
        }

        private void Delete()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            HttpResponseMessage result;
            switch (current_type)
            {
                case ExecutionType.Customer:
                    result = http.DeleteAsync("Customer/" + GetEnteredCustomer().custId).Result;
                    break;
                case ExecutionType.Product:
                    result = http.DeleteAsync("Product/" + GetEneteredProduct().prodId).Result;
                    break;
                case ExecutionType.Order:
                    result = http.DeleteAsync("Order/" + GetEnteredOrder().orderId).Result;
                    break;
                case ExecutionType.Cart:
                    result = http.DeleteAsync("Cart/" + GetEnteredCart().orderId + "/" + GetEnteredCart().prodId).Result;
                    break;
            }
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

        private Product GetEneteredProduct()
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
    }
}