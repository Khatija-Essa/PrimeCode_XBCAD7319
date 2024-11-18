using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure only authenticated admins can access
             if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
        }

        private string GenerateHash(string password, out string salt)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                salt = Convert.ToBase64String(saltBytes);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
                {
                    byte[] hashBytes = pbkdf2.GetBytes(20);
                    byte[] hashWithSaltBytes = new byte[36];
                    Array.Copy(saltBytes, 0, hashWithSaltBytes, 0, 16);
                    Array.Copy(hashBytes, 0, hashWithSaltBytes, 16, 20);

                    return Convert.ToBase64String(hashWithSaltBytes);
                }
            }
        }

        protected void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO [Admin] (username, password) VALUES (@Username, @Password)";
                    string salt;
                    string hashedPassword = GenerateHash(txtPassword.Text.Trim(), out salt);

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "New admin has been successfully created.";
                            lblMsg.CssClass = "alert alert-success";
                            ClearFields();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Failed to create a new admin. Please try again.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Username is already taken. Please choose a different one.";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error: " + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}