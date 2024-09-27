using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.IO;

namespace PrimeCode_XBCAD7319.User
{
    public partial class Resume : System.Web.UI.Page
    {
        SqlCommand cmd;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {//ensure user is logged in before opening the page
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {//based on the user id it will display some of the user information
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        //this will show the inofrtaion that saved in the database and users can either add more information to textboxes not filled out or edit thier information
        private void showUserInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    query = "SELECT * FROM [User] WHERE UserId=@userId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            txtFullName.Text = sdr["Name"].ToString();
                            txtUsername.Text = sdr["Username"].ToString();
                            txtAddress.Text = sdr["Address"].ToString();
                            txtMobile.Text = sdr["Mobile"].ToString();
                            txtEmail.Text = sdr["Email"].ToString();
                            ddlProvinces.SelectedValue = sdr["Province"].ToString();
                            txtHs.Text = sdr["Highschool"].ToString();
                            txtUniversity.Text = sdr["University"].ToString();
                            txtWE.Text = sdr["WorkExperience"].ToString();
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "User not found";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //to save their new information to the database 
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    if (Request.QueryString["id"] != null)
                    {
                        // Variables to store file paths
                        string resumePath = string.Empty;
                        string matricPath = string.Empty;
                        string idDocPath = string.Empty;
                        string transcriptPath = string.Empty;

                        // Validate and save each file if present
                        bool isResumeValid = Doc.HasFile && IsValidExtension(Doc.FileName);
                        bool isMatricValid = Doc1.HasFile && IsValidExtension(Doc1.FileName);
                        bool isIdDocValid = Doc2.HasFile && IsValidExtension(Doc2.FileName);
                        bool isTranscriptValid = Doc3.HasFile && IsValidExtension(Doc3.FileName);

                        // Create directories if they don't exist
                        string resumeDir = Server.MapPath("~/Resumes/");
                        string matricDir = Server.MapPath("~/Matric/");
                        string idDocDir = Server.MapPath("~/ID/");
                        string transcriptDir = Server.MapPath("~/Transcripts/");

                        if (!Directory.Exists(resumeDir)) Directory.CreateDirectory(resumeDir);
                        if (!Directory.Exists(matricDir)) Directory.CreateDirectory(matricDir);
                        if (!Directory.Exists(idDocDir)) Directory.CreateDirectory(idDocDir);
                        if (!Directory.Exists(transcriptDir)) Directory.CreateDirectory(transcriptDir);

                        // Start building the SQL query
                        query = @"UPDATE [User] SET 
                                    Username=@Username, 
                                    Name=@Name, 
                                    Email=@Email, 
                                    Mobile=@Mobile, 
                                    Highschool=@Highschool, 
                                    University=@University, 
                                    WorkExperience=@WorkExperience, 
                                    Address=@Address, 
                                    Province=@Province";

                        // Append file paths to the query if valid files are uploaded
                        if (isResumeValid) query += ", Resume=@Resume";
                        if (isMatricValid) query += ", Matric=@Matric";
                        if (isIdDocValid) query += ", ID=@ID";
                        if (isTranscriptValid) query += ", Transcript=@Transcript";

                        query += " WHERE UserId=@UserId";

                        // Initialize the SQL command
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Province", ddlProvinces.SelectedValue);
                        cmd.Parameters.AddWithValue("@Highschool", txtHs.Text);
                        cmd.Parameters.AddWithValue("@University", txtUniversity.Text);
                        cmd.Parameters.AddWithValue("@WorkExperience", txtWE.Text);
                        cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);

                        // Handle Resume file upload
                        if (isResumeValid)
                        {
                            Guid resumeGuid = Guid.NewGuid();
                            resumePath = "Resumes/" + resumeGuid.ToString() + Path.GetExtension(Doc.FileName);
                            Doc.SaveAs(resumeDir + resumeGuid.ToString() + Path.GetExtension(Doc.FileName));
                            cmd.Parameters.AddWithValue("@Resume", resumePath);
                        }

                        // Handle Matric Certificate file upload
                        if (isMatricValid)
                        {
                            Guid matricGuid = Guid.NewGuid();
                            matricPath = "Matric/" + matricGuid.ToString() + Path.GetExtension(Doc1.FileName);
                            Doc1.SaveAs(matricDir + matricGuid.ToString() + Path.GetExtension(Doc1.FileName));
                            cmd.Parameters.AddWithValue("@Matric", matricPath);
                        }

                        // Handle ID Document file upload
                        if (isIdDocValid)
                        {
                            Guid idDocGuid = Guid.NewGuid();
                            idDocPath = "ID/" + idDocGuid.ToString() + Path.GetExtension(Doc2.FileName);
                            Doc2.SaveAs(idDocDir + idDocGuid.ToString() + Path.GetExtension(Doc2.FileName));
                            cmd.Parameters.AddWithValue("@ID", idDocPath);
                        }

                        // Handle Transcript file upload
                        if (isTranscriptValid)
                        {
                            Guid transcriptGuid = Guid.NewGuid();
                            transcriptPath = "Transcripts/" + transcriptGuid.ToString() + Path.GetExtension(Doc3.FileName);
                            Doc3.SaveAs(transcriptDir + transcriptGuid.ToString() + Path.GetExtension(Doc3.FileName));
                            cmd.Parameters.AddWithValue("@Transcript", transcriptPath);
                        }

                        // Execute the query
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Document details updated successfully.";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Failed to update. Please try again later.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot update records at this time.";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }
        //method to ensure the documents saved are correct
        private bool IsValidExtension(string fileName)
        {
            string[] fileExtensions = { ".doc", ".docx", ".pdf" };
            string fileExtension = Path.GetExtension(fileName).ToLower();
            return fileExtensions.Contains(fileExtension);
        }
    }
}
/*Code Attribute for Resume
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */
