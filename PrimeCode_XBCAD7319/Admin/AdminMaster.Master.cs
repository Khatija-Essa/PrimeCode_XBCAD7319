using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null)
                {
                    litUserName.Text = $"Welcome : {Session["username"]}";
                    btnLogout.Visible = true;
                    LoadNotifications();
                }
                else
                {
                    btnLogout.Visible = false;
                    notification1.Text = "0";
                    notification2.Text = "0";
                }
            }
        }

        private void LoadNotifications()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PaymentSessions WHERE PaymentMade = 'yes'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                count = dt.Rows.Count;

                // We'll set these values, but they'll be updated by JavaScript
                notification1.Text = count.ToString();
                notification2.Text = count.ToString();

                r1.DataSource = dt;
                r1.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                notification1.Text = "0";
                notification2.Text = "0";
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        /*Code Attribute for AdminMaster(paymet notifcation)          
        *Source: https://youtu.be/jxGhb5gyP2s?si=YvFLFWCmjsHq6vJ4          
        *Creater : Amit Andipara         
        */

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../User/Default.aspx");
        }
    }
}
