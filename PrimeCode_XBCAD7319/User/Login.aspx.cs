using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace PrimeCode_XBCAD7319.User
{
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataReader sdr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userType = ddlUserType.SelectedValue;

                using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    con.Open();
                    string query = string.Empty;

                    // Set the appropriate query based on user type
                    switch (userType)
                    {
                        case "Admin":
                            query = @"SELECT AdminId AS Id, Username, Password FROM Admin WHERE Username = @Username";
                            break;
                        case "User":
                            query = @"SELECT UserId AS Id, Username, Password FROM [User] WHERE Username = @Username";
                            break;
                        case "Company":
                            query = @"SELECT CompanyId AS Id, Username, Password FROM Company WHERE Username = @Username";
                            break;
                        case "Partner":
                            query = @"SELECT PartnerId AS Id, Username, Password FROM Partner WHERE Username = @Username";
                            break;
                        default:
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please select a valid user type.";
                            lblMsg.CssClass = "alert alert-danger";
                            return;
                    }

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        string storedHash = sdr["Password"].ToString();
                        bool isPasswordValid = VerifyPassword(txtPassword.Text.Trim(), storedHash);

                        if (isPasswordValid)
                        {
                            Session["username"] = sdr["Username"].ToString();
                            Session["userId"] = sdr["Id"].ToString();

                            // Redirect based on user type
                            switch (userType)
                            {
                                case "Admin":
                                    Response.Redirect("../Admin/Dashboard.aspx", false);
                                    break;
                                case "User":
                                    Response.Redirect("../User/Profile.aspx", false);
                                    break;
                                case "Company":
                                    Response.Redirect("../Company/CompanyHome.aspx", false);
                                    break;
                                case "Partner":
                                    Response.Redirect("../Partner/PartnerProfile.aspx", false);
                                    break;
                            }
                        }
                        else
                        {
                            showErrorMsg(userType);
                        }
                    }
                    else
                    {
                        showErrorMsg(userType);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Verify the hashed password
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

        // Show error message
        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = $"{userType} information is incorrect.";
            lblMsg.CssClass = "alert alert-danger";
        }
    }
}
