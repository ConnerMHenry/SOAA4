using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestClient
{
    public partial class ActionPage : System.Web.UI.Page
    {
        private Action action;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string actionStr = Request.QueryString["action"];

                switch (actionStr)
                {
                    case "Delete":
                        action = Action.Delete;
                        break;

                    case "Update":
                        action = Action.Update;
                        break;

                    case "Insert":
                        action = Action.Insert;
                        break;

                    default:
                        action = Action.Search;
                        break;
                }

            }
            catch
            {
                action = Action.Search;
            }

            SetupUI();
        }

        private void SetupUI()
        {
            switch (action)
            {
                case Action.Delete:
                    ExecuteBtn.Text = "Delete";
                    break;

                case Action.Update:
                    ExecuteBtn.Text = "Update";
                    break;

                case Action.Insert:
                    ExecuteBtn.Text = "Insert";
                    break;

                default:
                    ExecuteBtn.Text = "Search";
                    break;
            }
            
        }
    }
}