using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Partner
{
    public partial class PartnerProfile : System.Web.UI.Page
    {
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {//make sure user is logged in before going to the page
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowPartnerProfile();
            }
        }
        //shows partner details and alows them to be able to edit it 
        private void ShowPartnerProfile()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PartnerId, Username, Name, Address, Mobile, Email, Province, ProfileImage FROM Partner WHERE Username=@username";
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
        /*Code Attribute for Partner Profile
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */
        //allows for partner to upload a prifle picture and saves it to the databse 
        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string commandArgument = e.CommandArgument.ToString();

            if (e.CommandName == "UploadImage")
            {
                FileUpload fuProfileImage = (FileUpload)e.Item.FindControl("fuProfileImage");

                if (fuProfileImage != null && fuProfileImage.HasFile)
                {
                    string fileExtension = Path.GetExtension(fuProfileImage.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        string filename = Path.GetFileNameWithoutExtension(fuProfileImage.FileName) + "_" + commandArgument + fileExtension;
                        string folderPath = "~/uploads/";
                        string savePath = Server.MapPath(folderPath + filename);

                        if (!Directory.Exists(Server.MapPath(folderPath)))
                        {
                            Directory.CreateDirectory(Server.MapPath(folderPath));
                        }

                        fuProfileImage.SaveAs(savePath);

                        UpdateProfileImage(int.Parse(commandArgument), folderPath + filename);

                        ShowPartnerProfile();
                    }
                    else
                    {
                        Response.Write("<script>alert('Only images (.jpg, .jpeg, .png, .gif) can be uploaded.');</script>");
                    }
                }
            }
            //allows ofr a mass uplaod of documents 
            else if (e.CommandName == "UploadMassFiles")
            {
                FileUpload fuMassUpload = (FileUpload)e.Item.FindControl("fuMassUpload");

                if (fuMassUpload != null && fuMassUpload.HasFiles)
                {
                    List<string> filePaths = new List<string>();

                    foreach (HttpPostedFile file in fuMassUpload.PostedFiles)
                    {
                        string fileExtension = Path.GetExtension(file.FileName).ToLower();
                        string[] allowedExtensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };

                        if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                        {
                            string filename = Path.GetFileNameWithoutExtension(file.FileName) + "_" + commandArgument + fileExtension;
                            string folderPath = "~/uploads/";
                            string savePath = Server.MapPath(folderPath + filename);

                            if (!Directory.Exists(Server.MapPath(folderPath)))
                            {
                                Directory.CreateDirectory(Server.MapPath(folderPath));
                            }

                            file.SaveAs(savePath);
                            filePaths.Add(folderPath + filename);
                        }
                        else
                        {
                            Response.Write("<script>alert('Only documents (.pdf, .doc, .docx, .xls, .xlsx) can be uploaded.');</script>");
                        }
                    }

                    if (filePaths.Count > 0)
                    {
                        UpdateMassFiles(int.Parse(commandArgument), filePaths);
                    }

                    ShowPartnerProfile();
                }
                else
                {
                    Response.Write("<script>alert('No files selected for upload.');</script>");
                }
            }
        }

        private void UpdateMassFiles(int partnerId, List<string> filePaths)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert new documents without deleting existing ones
                    foreach (var path in filePaths)
                    {
                        string insertQuery = "INSERT INTO PartnerDocuments (PartnerId, FilePath) VALUES (@PartnerId, @FilePath)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@PartnerId", partnerId);
                            insertCmd.Parameters.AddWithValue("@FilePath", path);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write("<script>alert('An error occurred while uploading the files.');</script>");
            }
        }
        //updates profile pictur eeverytime it changes 
        private void UpdateProfileImage(int partnerId, string filePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Partner SET ProfileImage=@ProfileImage WHERE PartnerId=@PartnerId";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProfileImage", filePath);
                        cmd.Parameters.AddWithValue("@PartnerId", partnerId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write("<script>alert('An error occurred while updating the profile image.');</script>");
            }
        }
        //saves parter changes to their profile
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Button btnSaveChanges = (Button)sender;
            string partnerId = btnSaveChanges.CommandArgument;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Partner SET Name = @Name, Email = @Email, Mobile = @Mobile, Address = @Address WHERE PartnerId = @PartnerId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", ((TextBox)dlProfile.Items[0].FindControl("txtName")).Text);
                cmd.Parameters.AddWithValue("@Email", ((TextBox)dlProfile.Items[0].FindControl("txtEmail")).Text);
                cmd.Parameters.AddWithValue("@Mobile", ((TextBox)dlProfile.Items[0].FindControl("txtPhone")).Text);
                cmd.Parameters.AddWithValue("@Address", ((TextBox)dlProfile.Items[0].FindControl("txtAddress")).Text);
                cmd.Parameters.AddWithValue("@PartnerId", partnerId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ShowPartnerProfile();
        }
    }
}

