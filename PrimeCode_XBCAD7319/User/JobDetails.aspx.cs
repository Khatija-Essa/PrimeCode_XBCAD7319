using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PrimeCode_XBCAD7319.User
{
    public partial class JobDetails : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showJobDetail();
            }
        }

        //this will display all the job details that the company have inputed on our new job page
        private void showJobDetail()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jobs WHERE JobId = @id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        //this is the check to see if a user has already applied for a job or not 
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ApplyJob")
            {
                if (Session["userId"] != null)
                {
                    if (!iSApplied(Convert.ToInt32(Session["userId"]), Convert.ToInt32(Request.QueryString["id"])))
                    {
                        try
                        {
                            using (SqlConnection con = new SqlConnection(connectionString))
                            {
                                string query = "INSERT INTO AppliedJobs (JobId, UserId) VALUES (@JobId, @userId)";
                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@JobId", Convert.ToInt32(Request.QueryString["id"]));
                                cmd.Parameters.AddWithValue("@userId", Convert.ToInt32(Session["userId"]));
                                con.Open();
                                int r = cmd.ExecuteNonQuery();
                                if (r > 0)
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "Job Applied Successfully";
                                    lblMsg.CssClass = "alert alert-success";
                                }
                                else
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "Could not apply now. Please try again later.";
                                    lblMsg.CssClass = "alert alert-danger";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "You have already applied for this job.";
                        lblMsg.CssClass = "alert alert-warning";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        //if the user has applied then the text will change to applied so they do not reaply
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["userId"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("btnApply") as LinkButton;
                if (btnApplyJob != null)
                {
                    int userId = Convert.ToInt32(Session["userId"]);
                    int jobId = Convert.ToInt32(Request.QueryString["id"]);

                    if (iSApplied(userId, jobId))
                    {
                        btnApplyJob.Enabled = false;
                        btnApplyJob.Text = "Applied";
                    }
                    else
                    {
                        btnApplyJob.Enabled = true;
                        btnApplyJob.Text = "Apply";
                    }
                }
            }
        }

        //to check if a user has already applied for this job or not 
        private bool iSApplied(int userId, int jobId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM AppliedJobs WHERE UserId = @UserId AND JobId = @JobId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@JobId", jobId);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        //to have the image display on the job details page
        protected string GetImageUrl(object url)
        {
            if (url == null || string.IsNullOrEmpty(url.ToString()))
            {
                return ResolveUrl("~/public/images/No_image.jpg");
            }
            else
            {
                return ResolveUrl($"~/{url}");
            }
        }
    }
}

/*Code Attribute for ContactList
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */