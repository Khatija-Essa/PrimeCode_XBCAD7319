using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class AppliedList : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                ShowAppliedJob(); // Initially show all applied jobs
            }
        }

        // Method to fetch and display the applied jobs based on search query
        private void ShowAppliedJob(string searchQuery = "")
        {
            string query = string.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Modified query to only show applications for the logged-in company's jobs
                query = @"SELECT Row_Number() OVER(ORDER BY (SELECT 1)) as [Sr.No], 
                         aj.AppliedJobId, j.CompanyName, aj.JobId, j.Title, 
                         u.WorkExperience, u.Name 
                         FROM AppliedJobs aj
                         INNER JOIN [User] u ON aj.UserId = u.UserId
                         INNER JOIN Jobs j ON aj.JobId = j.JobId
                         INNER JOIN Company c ON j.CompanyName = c.CompanyName
                         WHERE c.CompanyId = @CompanyId";

                // Apply additional filter if search query is provided
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    query += @" AND (j.Title LIKE @SearchQuery 
                              OR j.CompanyName LIKE @SearchQuery 
                              OR u.Name LIKE @SearchQuery 
                              OR u.WorkExperience LIKE @SearchQuery)";
                }

                cmd = new SqlCommand(query, con);

                // Add company ID parameter
                cmd.Parameters.AddWithValue("@CompanyId", Session["userId"].ToString());

                // Add search parameter if provided
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    lblMsg.Visible = false;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblMsg.Visible = true;
                    lblMsg.Text = "No applications found.";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
        }

        // Method to handle search button click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            ShowAppliedJob(searchQuery);
        }

        // Method to handle pagination in GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAppliedJob(txtSearch.Text.Trim());
        }

        // Method to handle the clear button click
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ShowAppliedJob();
        }
    }
}