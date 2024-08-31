using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Web.UI;
using System.Xml.Linq;

namespace PrimeCode_XBCAD7319.User
{
    public partial class contact : System.Web.UI.Page
    {
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtSend_Click(object sender, EventArgs e)
        {
            try
            {//have the data the user inputed save to the database
                using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    string query = @"Insert into Contact values (@Name, @email, @message)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Value.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Value.Trim());
                    cmd.Parameters.AddWithValue("@message", txtMessage.Value.Trim());
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Your message has been sent and your query will be looked into.";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot save record right now, try again later!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //clears out the message after the message has been sent 
        private void clear()
        {
            txtName.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtMessage.Value = string.Empty;
        }
    }
}
/*Code Attribute for ContactList
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */