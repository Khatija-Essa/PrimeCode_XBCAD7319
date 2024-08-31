using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class CompanyHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check company is logged in first
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }
        //redicts them to the payment page when they click on the button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Payment.aspx");
        }

        //redirect them to the add a job when they click on the button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/NewJob.aspx");
        }
    }
}