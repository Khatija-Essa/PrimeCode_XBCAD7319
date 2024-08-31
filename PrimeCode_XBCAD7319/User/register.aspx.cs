using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PrimeCode_XBCAD7319.User
{
    public partial class register : System.Web.UI.Page
    {
        SqlCommand cmd;

        private string GenerateHash(string password, out string salt)
        {//code for hashing the passwords
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    string query = "";
                    // Determine which table to insert data into based on selected user type
                    switch (ddlUserType.SelectedValue)
                    {
                        case "user":
                            query = @"Insert into [User] (Username, Password, Name, Email, Mobile, Address, Province) 
                                      values (@Username, @Password, @Name, @Email, @Mobile, @Address, @Province)";
                            break;
                        case "company":
                            query = @"Insert into [Company] (Username, Password, Name, Email, Mobile, Address, Province) 
                                      values (@Username, @Password, @Name, @Email, @Mobile, @Address, @Province)";
                            break;
                        case "partner":
                            query = @"Insert into [Partner] (Username, Password, Name, Email, Mobile, Address, Province) 
                                      values (@Username, @Password, @Name, @Email, @Mobile, @Address, @Province)";
                            break;
                        default:
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please select a valid user type!";
                            lblMsg.CssClass = "alert alert-danger";
                            return;
                    }

                    // Hash the password
                    string salt;
                    string hashedPassword = GenerateHash(txtComfirmPassword.Text.Trim(), out salt);

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Province", ddlProvinces.SelectedValue);

                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Your Registration has been successfully saved!";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot save record right now, try again later!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = txtUserName.Text.Trim() + " User Name is already taken, try a different name!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //clears data once it is saved to the databse
        private void clear()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtComfirmPassword.Text = string.Empty;
            ddlProvinces.ClearSelection();
            ddlUserType.ClearSelection();
        }
    }
}
