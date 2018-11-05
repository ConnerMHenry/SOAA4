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

            }
            catch
            {
                userOption = Option.SEARCH;
            }

        }

        protected void ExecuteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}