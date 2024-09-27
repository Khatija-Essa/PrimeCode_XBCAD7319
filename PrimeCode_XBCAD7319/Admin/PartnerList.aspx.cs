using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class PartnerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//make sure user is logged in before they can go to the page 
            if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //display the data from the databse 
            if (!IsPostBack)
            {
                ShowPartnerList();
            }
        }
        //code to get the data from both the partner databse and the user databse 
        private void ShowPartnerList()
        {
            string connectionString = "Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string query = @"
            SELECT 
                p.PartnerId,
                p.Username,
                p.Email,
                p.Mobile,
                STRING_AGG(pd.FilePath, '; ') AS Documents
            FROM 
                Partner p
            LEFT JOIN 
                PartnerDocuments pd ON p.PartnerId = pd.PartnerId
            GROUP BY 
                p.PartnerId, p.Username, p.Email, p.Mobile
            ORDER BY 
                p.Username";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
        //to be able to have more then one table
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowPartnerList();
        }
        //to delete a row 
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Extract PartnerId from the GridView row
                int partnerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["PartnerId"]);

                // Check if PartnerId is valid
                if (partnerId <= 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Invalid Partner ID.";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }

                string connectionString = "Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string query = "DELETE FROM PartnerDocuments WHERE PartnerId = @PartnerId";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PartnerId", partnerId);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Delete successful";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "No documents found for deletion.";
                            lblMsg.CssClass = "alert alert-warning";
                        }
                    }
                }

                // Refresh the GridView to reflect changes
                ShowPartnerList();
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }
        //to het the document for a mass upload of the partner document and display it on admin
        public string GetDocumentLinks(string documentPaths)
        {
            var links = documentPaths.Split(new[] { "; " }, StringSplitOptions.None);
            var htmlLinks = "";
            foreach (var path in links)
            {
                var fileName = System.IO.Path.GetFileName(path);
                var relativePath = ResolveUrl("~/uploads/" + fileName); // Construct the relative URL
                htmlLinks += $"<a href='{relativePath}'>{fileName}</a><br />";
            }
            return htmlLinks;
        }
    }
}
