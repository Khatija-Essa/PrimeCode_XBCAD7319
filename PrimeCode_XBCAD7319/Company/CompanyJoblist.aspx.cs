using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class CompanyJoblist : System.Web.UI.Page
    {
        SqlCommand cmd;
      

        DataTable dt;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // If the user is not logged in, redirect to login page
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            // Display the job list only if it's not a postback
            if (!IsPostBack)
            {
                ShowJob();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Show the job list on page load
            ShowJob();
        }

        // Method to get the data from the database and display it in the table
        private void ShowJob()
        {
            string query = string.Empty;
           

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Fetch all jobs (no company filter)
                query = @"SELECT Row_Number() OVER(ORDER BY (SELECT 1)) AS [Sr.No], 
                 JobId, Title, NoOfPost, Description, Qualification, 
                 Experience, LastDateToApply, CompanyName, Province, CreateDate 
                 FROM Jobs 
                 WHERE CompanyId = @CompanyId";

                cmd.Parameters.AddWithValue("@CompanyId", Session["userId"]);
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // Handle pagination for the GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
        }

        // Handle job deletion (for all jobs)
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int jobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("DELETE FROM Jobs WHERE JobId = @id", con); // No company filter
                    cmd.Parameters.AddWithValue("@id", jobId);
                    con.Open();

                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Deleted Successfully.";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Could not delete.";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                    GridView1.EditIndex = -1;
                    ShowJob();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Handle job editing (no company filter)
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                Response.Redirect("../Company/NewJob.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        // Change row color when a query parameter is present (e.g., from job details page)
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ID = e.Row.RowIndex.ToString();
                if (Request.QueryString["id"] != null)
                {
                    int jobId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values[0]);
                    if (jobId == Convert.ToInt32(Request.QueryString["id"]))
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#A5C8D4");
                    }
                }
            }
        }
    }
}
