using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestServices.Models;

namespace CrazyMelvinsCleint
{
    public partial class SecondPage : System.Web.UI.Page
    {
        private Option userOption;
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

        protected void ExecuteBtn_Click(object sender, EventArgs e)
        {
            // Check if each validator is valid
            bool valid = true;
            foreach (BaseValidator validator in validators)
            {
                validator.Validate();
                if (!validator.IsValid)
                {
                    valid = false;
                    break;
                }
            }

            // If not, don't execute the function
            if (!valid)
            {
                return;
            }

            Customer customer = new Customer()
            {
                custId = Convert.ToInt32(CustID.Text.ToString()),
                firstName = FirstName.Text.ToString(),
                lastName = LastName.Text.ToString(),
                phoneNumber = PhoneNumber.Text.ToString()
            };

            Product product = new Product()
            {
                prodId = Convert.ToInt32(ProdID.Text.ToString()),
                prodName = ProductName.Text.ToString(),
                prodWeight = Convert.ToDecimal(ProdWeight.Text.ToString()),
                inStock = InStock.Checked,
                price = Convert.ToDecimal(Price.Text.ToString())
            };

            Order order = new Order()
            {
                orderId  = Convert.ToInt32(OrderID.Text.ToString()),
                custId = Convert.ToInt32(OrderCustID.Text.ToString()),
                orderDate = Convert.ToDateTime(OrderDate.Text.ToString()),
                poNumber = PoNumber.Text.ToString()
            };

            Cart cart = new Cart()
            {
                orderId = Convert.ToInt32(CartOrderID.Text.ToString()),
                prodId = Convert.ToInt32(CartProductID.Text.ToString()),
                quantity = Convert.ToInt32(Quantity.Text.ToString())
            };


            //switch (userOption)
            //{
            //    case Option.Search:
            //        Search();
            //        break;

            //    case Option.Update:
            //        Update();
            //        break;

            //    case Option.Delete:
            //        Delete();
            //        break;

            //    default:
            //        Insert();
            //        break;
            //}
        }

        private void Search()
        {

        }

        private void Insert()
        {

        }

        private void Update()
        {

        }

        private void Delete()
        {

        }

    }
}