using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrazyMelvinsCleint
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SecondPage.aspx?option=Search");
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SecondPage.aspx?option=Insert");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SecondPage.aspx?option=Update");
        }

        protected void DeletBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SecondPage.aspx?option=Delete");
        }
    }
}