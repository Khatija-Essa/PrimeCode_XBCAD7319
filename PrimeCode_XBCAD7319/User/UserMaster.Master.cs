using System;

namespace PrimeCode_XBCAD7319.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {//will display after user is logged in
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
        //allows user to log out and be redirect to the default page
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}
