using System;
using System.Web.UI;

namespace PrimeCode_XBCAD7319.User
{
    public partial class Conditions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            // Server-side validation to ensure the checkbox is checked
            if (CheckBox1.Checked)
            {
                // Redirect to the Register.aspx page if the checkbox is checked
                Response.Redirect("Register.aspx");
            }
            else
            {
                // Show an error message if the checkbox is not checked
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You must accept the terms and conditions before proceeding.');", true);
            }
        }
    }
}
