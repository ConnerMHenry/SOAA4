using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrazyMelvinsCleint
{
    public partial class SecondPage : System.Web.UI.Page
    {
        private Option userOption;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            SetupUI();
        }

        private void SetupUI()
        {
            switch(userOption)
            {
                case Option.Search:
                    DisplayLbl.Text = "Search for customer orders";
                    break;

                case Option.Update:
                    DisplayLbl.Text = "Update your order!";
                    break;

                case Option.Delete:
                    DisplayLbl.Text = "Please delete something. Hopefully this site.";
                    break;

                default:
                    DisplayLbl.Text = "Please generate a Purchase Order (P.O.)";
                    break;
            }
        }

        protected void ExecuteBtn_Click(object sender, EventArgs e)
        {
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