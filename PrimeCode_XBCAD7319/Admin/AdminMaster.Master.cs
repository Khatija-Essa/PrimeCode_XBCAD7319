using System;
using System.Web.UI;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {//will display once user is logged in 
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
        //allows user to log out and redirects them to the default page

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../User/Default.aspx");
        }
    }
}
