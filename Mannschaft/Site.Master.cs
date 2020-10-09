using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    public partial class SiteMaster : MasterPage
    {
        public controller Verwalter { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove ("Verwalter");
            Response.Redirect("~/Login.aspx");
        }



    }
}