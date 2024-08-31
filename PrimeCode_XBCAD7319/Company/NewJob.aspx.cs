using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace PrimeCode_XBCAD7319.Company
{
    public partial class NewJob : System.Web.UI.Page
    {
        SqlCommand cmd;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {//the correct title if it is a new job other wise title would be edit job which only admin can do 
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData(); //ensure user fills all the data in
            }

        }
        //saves the data to the databse
        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
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
                            //title for when admin edit a job
                            btnAdd.Text = "Update";
                            Session["title"] = "Edit Job";
                            linkback.Visible = true;
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Job not found!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    sdr.Close();
                    con.Close();
                }
            }
        }
        //saves data to the databse 
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string queryType;
                bool isValidToExecute = false;
                string imagePath = string.Empty;

                using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
                {
                    if (Request.QueryString["id"] != null)
                    {
                        queryType = "Updated";
                        query = @"UPDATE Jobs SET Title = @Title, NoOfPost = @NoOfPost, Description = @Description, Qualification = @Qualification,
                                  Experience = @Experience, Specialization = @Specialization, LastDateToApply = @LastDateToApply, 
                                  Salary = @Salary, JobType = @JobType, CompanyName = @CompanyName, Website = @Website, 
                                  Email = @Email, Address = @Address, Province = @Province";
                        //save the image to the database 
                        if (CompanyLogo.HasFile && IsValidExtension(CompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + System.IO.Path.GetExtension(CompanyLogo.FileName);
                            CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + System.IO.Path.GetExtension(CompanyLogo.FileName));
                            query += ", CompanyImage = @CompanyImage";
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        }

                        query += " WHERE JobId = @JobId";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                    }
                    else
                    {
                        queryType = "Saved";
                        query = @"INSERT INTO Jobs (Title, NoOfPost, Description, Qualification, Experience, Specialization, LastDateToApply, 
                                  Salary, JobType, CompanyName, CompanyImage, Website, Email, Address, Province, CreateDate) 
                                  VALUES (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, 
                                  @Salary, @JobType, @CompanyName, @CompanyImage, @Website, @Email, @Address, @Province, @CreateDate)";

                        DateTime time = DateTime.Now;
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));

                        if (CompanyLogo.HasFile && IsValidExtension(CompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + System.IO.Path.GetExtension(CompanyLogo.FileName);
                            CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + System.IO.Path.GetExtension(CompanyLogo.FileName));
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CompanyImage", DBNull.Value);
                        }
                    }
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
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
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //clear data once a job is saved 
        private void clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNoPost.Text = string.Empty;
            txtDescription.Text = string.Empty;
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
            string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
            return fileExtensions.Contains(fileExtension);
        }
    }
}
/*Code Attribute for New Job
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */
