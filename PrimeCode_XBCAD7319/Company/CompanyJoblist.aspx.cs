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
        SqlConnection con;
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
            // Load jobs when page is first loaded
            if (!IsPostBack)
            {
                ShowJob();
            }
        }

        // Method to fetch and display jobs from the database
        private void ShowJob()
        {
            try
            {
                using (con = new SqlConnection(connectionString))
                {
                    // Query to get jobs for the logged-in company
                    string query = @"SELECT Row_Number() OVER(ORDER BY j.CreateDate DESC) AS [Sr.No], 
                                   j.JobId, j.Title, j.NoOfPost, j.Description, j.Qualification, 
                                   j.Experience, j.LastDateToApply, j.CompanyName, j.Province, j.CreateDate 
                                   FROM Jobs j
                                   INNER JOIN Company c ON j.CompanyName = c.CompanyName
                                   WHERE c.CompanyId = @CompanyId";
                    
              

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CompanyId", Session["userId"]);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    // Bind data to GridView
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    // Show message if no jobs are found
                    if (dt.Rows.Count == 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "No jobs found for your company.";
                        lblMsg.CssClass = "alert alert-info";
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message if something goes wrong
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        // Handle pagination for the GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
        }

        // Handle job deletion
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int jobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                using (con = new SqlConnection(connectionString))
                {
                    // Delete job only if it belongs to the logged-in company
                    cmd = new SqlCommand(@"DELETE FROM Jobs 
                                         WHERE JobId = @id AND CompanyName IN 
                                         (SELECT Name FROM Company WHERE CompanyId = @CompanyId)", con);

                    cmd.Parameters.AddWithValue("@id", jobId);
                    cmd.Parameters.AddWithValue("@CompanyId", Session["userId"]);
                    con.Open();

                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        // Success message
                        lblMsg.Visible = true;
                        lblMsg.Text = "Job deleted successfully.";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        // Error message if deletion fails
                        lblMsg.Visible = true;
                        lblMsg.Text = "Could not delete the job.";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                    GridView1.EditIndex = -1;
                    ShowJob();
                }
            }
            catch (Exception ex)
            {
                // Display error message if something goes wrong
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        // Handle edit job command
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                // Redirect to edit job page with job ID
                Response.Redirect("NewJob.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        // Handle row styling and highlighting
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ID = e.Row.RowIndex.ToString();

                // Highlight the row if it matches the query string ID
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