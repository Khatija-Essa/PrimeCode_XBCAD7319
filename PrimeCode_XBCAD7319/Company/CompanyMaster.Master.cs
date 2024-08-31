using System;
using System.Web.UI;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class CompanyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //will display after the user is logged in 
            if (!IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null)
                {
                    litUserName.Text = $"Welcome : {Session["username"]} ";
                    btnLogout.Visible = true;
                }
                else
                {
                    btnLogout.Visible = false;
                }
            }
        }
        //allow user to log our and be redirect to the default home page 
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../User/Default.aspx");
        }
    }
}
