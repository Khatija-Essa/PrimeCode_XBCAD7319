using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class Payment : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //checks the user is logged in before being redirected to the page 
            if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //display the payment detail
            if (!IsPostBack)
            {
                ShowPaymentDetails();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPaymentDetails();
        }

        //will display payment details with what user type  and thier email by check which username matches the payment username. looks at the user and company databse.
        private void ShowPaymentDetails()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                // Query to join PaymentSessions with User and Company tables
                string query = @"
        SELECT ps.Id AS [Payment Id], 
               ps.Username, 
               ps.[Plan],   
               COALESCE(u.Email, c.Email) AS Email, 
               CASE 
                   WHEN u.Username IS NOT NULL THEN 'User' 
                   WHEN c.Username IS NOT NULL THEN 'Company' 
               END AS [User Type],
               ps.CreatedAt AS [Payment Date]  
        FROM PaymentSessions ps
        LEFT JOIN [User] u ON ps.Username = u.Username
        LEFT JOIN Company c ON ps.Username = c.Username
        ORDER BY ps.CreatedAt ASC";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }



        //to be bale to have more then one table 
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowPaymentDetails();
        }

      
    }
}