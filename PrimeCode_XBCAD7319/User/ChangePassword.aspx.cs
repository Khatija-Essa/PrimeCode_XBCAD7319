using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataReader sdr;
        private static readonly string connectionString = "Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string userType = ddlUserType.SelectedValue;
                string username = txtUsername.Text.Trim();
                string currentPassword = txtCurrentPassword.Text.Trim();
                string newPassword = txtNewPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                // Validate new passwords match
                if (newPassword != confirmPassword)
                {
                    ShowErrorMessage("New passwords do not match!");
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = GetQueryByUserType(userType);

                    if (string.IsNullOrEmpty(query))
                    {
                        ShowErrorMessage("Please select a valid user type.");
                        return;
                    }

                    // Verify current password
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        string storedHash = sdr["Password"].ToString();
                        string userId = sdr["Id"].ToString();

                        if (VerifyPassword(currentPassword, storedHash))
                        {
                            sdr.Close();

                            // Generate new password hash
                            string newPasswordHash = HashPassword(newPassword);

                            // Update password
                            string updateQuery = GetUpdateQueryByUserType(userType);
                            cmd = new SqlCommand(updateQuery, con);
                            cmd.Parameters.AddWithValue("@Password", newPasswordHash);
                            cmd.Parameters.AddWithValue("@Username", username);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                ShowSuccessMessage("Password changed successfully!");
                            }
                            else
                            {
                                ShowErrorMessage("Failed to update password. Please try again.");
                            }
                        }
                        else
                        {
                            ShowErrorMessage("Current password is incorrect!");
                        }
                    }
                    else
                    {
                        ShowErrorMessage($"No {userType} found with the provided username.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("An error occurred: " + ex.Message);
            }
        }

        private string GetQueryByUserType(string userType)
        {
            switch (userType)
            {
               /* case "Admin":
                    return @"SELECT AdminId AS Id, Username, Password FROM Admin WHERE Username = @Username";*/
                case "User":
                    return @"SELECT UserId AS Id, Username, Password FROM [User] WHERE Username = @Username";
                case "Company":
                    return @"SELECT CompanyId AS Id, Username, Password FROM Company WHERE Username = @Username";
                case "Partner":
                    return @"SELECT PartnerId AS Id, Username, Password FROM Partner WHERE Username = @Username";
                default:
                    return string.Empty;
            }
        }

        private string GetUpdateQueryByUserType(string userType)
        {
            switch (userType)
            {
               /* case "Admin":
                    return "UPDATE Admin SET Password = @Password WHERE Username = @Username";*/
                case "User":
                    return "UPDATE [User] SET Password = @Password WHERE Username = @Username";
                case "Company":
                    return "UPDATE Company SET Password = @Password WHERE Username = @Username";
                case "Partner":
                    return "UPDATE Partner SET Password = @Password WHERE Username = @Username";
                default:
                    return string.Empty;
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(storedHash);

            if (hashWithSaltBytes.Length != 36)
            {
                return false;
            }

            byte[] saltBytes = new byte[16];
            Array.Copy(hashWithSaltBytes, 0, saltBytes, 0, 16);

            byte[] storedHashBytes = new byte[20];
            Array.Copy(hashWithSaltBytes, 16, storedHashBytes, 0, 20);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] computedHashBytes = pbkdf2.GetBytes(20);

                for (int i = 0; i < storedHashBytes.Length; i++)
                {
                    if (storedHashBytes[i] != computedHashBytes[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                return Convert.ToBase64String(hashBytes);
            }
        }

        private void ShowErrorMessage(string message)
        {
            lblMsg.Visible = true;
            lblMsg.Text = message;
            lblMsg.CssClass = "bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative mt-2 text-center";
        }

        private void ShowSuccessMessage(string message)
        {
            lblMsg.Visible = true;
            lblMsg.Text = message;
            lblMsg.CssClass = "bg-green-100 border border-green-400 text-green-700 px-4 py-3 rounded relative mt-2 text-center";
        }
    }
}