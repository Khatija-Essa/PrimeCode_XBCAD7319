using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {//check the user is logged in 
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowCompanyProfile();
            }
        }
        //will have the company details from the company databse 
        private void ShowCompanyProfile()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT CompanyId, Username, Name, Address, Mobile, Email, Province,CompanyName, ProfileImage FROM Company WHERE Username=@username";
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
                    Response.Write("<script>alert('No profile data found. Please log in again.');</script>");
                    Response.Redirect("Login.aspx");
                }
            }
        }
        //allows company to uplaod a porfile picture and saves it to the databse
        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "UploadImage")
            {
                FileUpload fuProfileImage = (FileUpload)e.Item.FindControl("fuProfileImage");

                if (fuProfileImage.HasFile)
                {
                    string fileExtension = Path.GetExtension(fuProfileImage.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        string filename = Path.GetFileNameWithoutExtension(fuProfileImage.FileName) + "_" + e.CommandArgument + fileExtension;
                        string folderPath = "~/CompanyImages/";
                        string savePath = Server.MapPath(folderPath + filename);

                        if (!Directory.Exists(Server.MapPath(folderPath)))
                        {
                            Directory.CreateDirectory(Server.MapPath(folderPath));
                        }

                        fuProfileImage.SaveAs(savePath);

                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            string query = "UPDATE Company SET ProfileImage = @ProfileImage WHERE CompanyId = @CompanyId";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ProfileImage", folderPath + filename);
                            cmd.Parameters.AddWithValue("@CompanyId", e.CommandArgument.ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        ShowCompanyProfile();
                    }
                    else
                    {
                        Response.Write("<script>alert('Only images (.jpg, .jpeg, .png, .gif) can be uploaded.');</script>");
                    }
                }
            }
        }
        //company can change their details and save it to the databse 
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Button btnSaveChanges = (Button)sender;
            string companyId = btnSaveChanges.CommandArgument;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Company SET Name = @Name, Email = @Email, Mobile = @Mobile, CompanyName = @CompanyName, Address = @Address WHERE CompanyId = @CompanyId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", ((TextBox)dlProfile.Items[0].FindControl("txtName")).Text);
                cmd.Parameters.AddWithValue("@Email", ((TextBox)dlProfile.Items[0].FindControl("txtEmail")).Text);
                cmd.Parameters.AddWithValue("@Mobile", ((TextBox)dlProfile.Items[0].FindControl("txtPhone")).Text);
                cmd.Parameters.AddWithValue("@CompanyName", ((TextBox)dlProfile.Items[0].FindControl("companyname")).Text);
                cmd.Parameters.AddWithValue("@Address", ((TextBox)dlProfile.Items[0].FindControl("txtAddress")).Text);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ShowCompanyProfile();
        }

      
    }
}
/*Code Attribute for Company Profile
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */