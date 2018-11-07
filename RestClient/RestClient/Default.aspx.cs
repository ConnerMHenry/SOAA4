using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchLbl_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ActionPage.aspx?action=Search");
        }

        protected void insertLbl_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ActionPage.aspx?action=Insert");
        }

        protected void updateLbl_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ActionPage.aspx?action=Update");
        }

        protected void deleteLbl_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ActionPage.aspx?action=Delete");
        }
    }
}