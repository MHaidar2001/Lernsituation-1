using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    
    public partial class _Default : Page
    {
        private controller _verwalter;
        public controller Verwalter { get => _verwalter; set => _verwalter = value; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["verwalter"] ==null)
            {
                Response.Redirect("~/Login.aspx");

            }
            else
            {
            }
         
        }
    }
}