using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class NewJob : System.Web.UI.Page
    {
        SqlCommand cmd;
        string query;
        string connectionString = "Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["title"] = "Add Job";
                fillData();
                SetLastDateValidation();
            }
        }

        private void SetLastDateValidation()
        {
            cvLastDate.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                Session["title"] = "Edit Job";
                linkback.Visible = true;
                btnAdd.Text = "Update";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    query = "SELECT * FROM Jobs WHERE JobId = @JobId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            txtJobTitle.Text = sdr["Title"].ToString();
                            txtNoPost.Text = sdr["NoOfPost"].ToString();
                            txtDescription.Text = sdr["Description"].ToString();
                            txtQualification.Text = sdr["Qualification"].ToString();
                            txtExperience.Text = sdr["Experience"].ToString();
                            txtSpecialization.Text = sdr["Specialization"].ToString();
                            txtLastDate.Text = Convert.ToDateTime(sdr["LastDateToApply"]).ToString("yyyy-MM-dd");
                            txtSalary.Text = sdr["Salary"].ToString();
                            ddlJobType.SelectedValue = sdr["JobType"].ToString();
                            txtCompany.Text = sdr["CompanyName"].ToString();
                            txtWebsite.Text = sdr["Website"].ToString();
                            txtEmail.Text = sdr["Email"].ToString();
                            txtAddress.Text = sdr["Address"].ToString();
                            ddlProvinces.SelectedValue = sdr["Province"].ToString();
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Job not found!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    sdr.Close();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string queryType;
                string imagePath = string.Empty;
                bool isValidToExecute = false;

                if (Request.QueryString["id"] != null)
                {
                    queryType = "Updated";
                    isValidToExecute = true;
                }
                else
                {
                    queryType = "Saved";
                    if (CompanyLogo.HasFile)
                    {
                        if (IsValidExtension(CompanyLogo.FileName))
                        {
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please select .jpg, .jpeg or .png image formats";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }
                }

                if (isValidToExecute)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            query = @"UPDATE Jobs SET Title = @Title, NoOfPost = @NoOfPost, Description = @Description, Qualification = @Qualification,
                                      Experience = @Experience, Specialization = @Specialization, LastDateToApply = @LastDateToApply, 
                                      Salary = @Salary, JobType = @JobType, CompanyName = @CompanyName, Website = @Website, 
                                      Email = @Email, Address = @Address, Province = @Province";

                            if (CompanyLogo.HasFile)
                            {
                                Guid obj = Guid.NewGuid();
                                imagePath = "Images/" + obj.ToString() + Path.GetExtension(CompanyLogo.FileName);
                                CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + Path.GetExtension(CompanyLogo.FileName));
                                query += ", CompanyImage = @CompanyImage";
                            }

                            query += " WHERE JobId = @JobId";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                        }
                        else
                        {
                            query = @"INSERT INTO Jobs (Title, NoOfPost, Description, Qualification, Experience, Specialization, LastDateToApply, 
                                      Salary, JobType, CompanyName, CompanyImage, Website, Email, Address, Province, CreateDate) 
                                      VALUES (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, 
                                      @Salary, @JobType, @CompanyName, @CompanyImage, @Website, @Email, @Address, @Province, @CreateDate)";

                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                            if (CompanyLogo.HasFile)
                            {
                                Guid obj = Guid.NewGuid();
                                imagePath = "Images/" + obj.ToString() + Path.GetExtension(CompanyLogo.FileName);
                                CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + Path.GetExtension(CompanyLogo.FileName));
                            }
                        }

                        cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@NoOfPost", Convert.ToInt32(txtNoPost.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                        cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                        cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastDateToApply", Convert.ToDateTime(txtLastDate.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                        cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                        cmd.Parameters.AddWithValue("@CompanyImage", string.IsNullOrEmpty(imagePath) ? DBNull.Value : (object)imagePath);
                        cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Province", ddlProvinces.SelectedValue);

                        con.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = $"Job {queryType} successfully!";
                            lblMsg.CssClass = "alert alert-success";
                            clear();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = $"Unable to {queryType} the job, please try again later.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
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

        private void clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNoPost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtLastDate.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlJobType.ClearSelection();
            ddlProvinces.ClearSelection();
        }

        private bool IsValidExtension(string fileName)
        {
            string[] fileExtensions = { ".jpg", ".png", ".jpeg" };
            return fileExtensions.Contains(Path.GetExtension(fileName).ToLower());
        }
    }
}
/*Code Attribute for New Job
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */
