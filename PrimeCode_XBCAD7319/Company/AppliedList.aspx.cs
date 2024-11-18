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
                query = @"Select Row_Number() over(Order by(Select 1)) as [Sr.No], aj.AppliedJobId, j.CompanyName, aj.JobId, j.Title, u.WorkExperience,
                          u.Name from AppliedJobs aj
                          inner join [User] u on aj.UserId = u.UserId
                          inner join Jobs j on aj.JobId = j.JobId ";

                // Apply filter if search query is provided
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    query += " WHERE j.Title LIKE @SearchQuery OR j.CompanyName LIKE @SearchQuery OR u.Name LIKE @SearchQuery OR u.WorkExperience LIKE @SearchQuery";
                }

                cmd = new SqlCommand(query, con);
                // Add parameterized query to prevent SQL injection
                cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // Method to handle search button click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search term from the TextBox
            string searchQuery = txtSearch.Text.Trim();
            // Call the ShowAppliedJob method with the search query
            ShowAppliedJob(searchQuery);
        }

        // Method to handle pagination in GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page index for GridView
            GridView1.PageIndex = e.NewPageIndex;
            // Re-fetch and bind data
            ShowAppliedJob(txtSearch.Text.Trim());
        }

        // Method to handle the clear button click
        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the search text box
            txtSearch.Text = string.Empty;
            // Call ShowAppliedJob method with an empty search query to reset the grid
            ShowAppliedJob();
        }
    }
}
