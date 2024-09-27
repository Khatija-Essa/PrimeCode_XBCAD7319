using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.User
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;

        protected void Page_Load(object sender, EventArgs e)
        {//make sure use ris logged in before redirecting to the page
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                showUserProfile();
            }
        }
        //display user details 
        private void showUserProfile()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                string query = "SELECT UserId, Username, Name, Address, Mobile, Email, Resume, ID, Matric, Transcript, Province, ProfileImage FROM [User] WHERE Username=@username";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dlProfile.DataSource = dt;
                    dlProfile.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please log in again with your latest username');</script>");
                }
            }
        }
        //code to redirect user to thier cv page in which they can fill in extra informatio ot create their cv 
        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "CreateCv")
            {
                Response.Redirect("Resume.aspx?id=" + e.CommandArgument.ToString());
            }

            /*Code Attribute for Profile
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */

            //code for user to upload a prifle picture
            else if (e.CommandName == "UploadImage")
            {
                FileUpload fuProfileImage = (FileUpload)e.Item.FindControl("fuProfileImage");

                if (fuProfileImage.HasFile)
                {
                    string fileExtension = Path.GetExtension(fuProfileImage.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        string filename = Path.GetFileNameWithoutExtension(fuProfileImage.FileName) + "_" + e.CommandArgument + fileExtension;
                        string folderPath = "~/UserImages/";
                        string savePath = Server.MapPath(folderPath + filename);

                        // Ensure the directory exists; if not, create it
                        string directoryPath = Server.MapPath(folderPath);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        // Save the file
                        fuProfileImage.SaveAs(savePath);

                        // Save the relative file path to the database
                        using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                        {
                            string query = "UPDATE [User] SET ProfileImage = @ProfileImage WHERE UserId = @UserId";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ProfileImage", folderPath + filename);
                            cmd.Parameters.AddWithValue("@UserId", e.CommandArgument.ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        // Refresh the profile to display the new image
                        showUserProfile();
                    }
                    else
                    {
                        Response.Write("<script>alert('Only images (.jpg, .jpeg, .png, .gif) can be uploaded.');</script>");
                    }
                }
            }
        }
    }
}
