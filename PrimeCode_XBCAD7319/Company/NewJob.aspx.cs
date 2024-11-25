using System;
using System.Configuration;
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
        // Connection string to the database
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is being loaded for the first time
            if (!IsPostBack)
            {
                // Set session title for page
                Session["title"] = "Add Job";
                LoadProvinces(); // Load provinces first
                LoadMajorCities(); // Then load cities
                SetLastDateValidation(); // Set the validation for the Last Date field
                fillData(); // Finally fill the data if editing
            }
        }

        /// <summary>
        /// Sets the validation for the Last Date field to ensure no past dates
        /// </summary>
        private void SetLastDateValidation()
        {
            // Set the Last Date validation to ensure no past dates are entered
            cvLastDate.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Loads the provinces into the dropdown list from the database
        /// </summary>
        private void LoadProvinces()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT [ProvinceName] FROM [Province]";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlProvinces.DataSource = reader;
                        ddlProvinces.DataTextField = "ProvinceName";
                        ddlProvinces.DataValueField = "ProvinceName";
                        ddlProvinces.DataBind();
                    }
                }
            }
            ddlProvinces.Items.Insert(0, new ListItem("Select Province", "0"));
        }

        /// <summary>
        /// Loads the major cities into the dropdown list from the database
        /// </summary>
        private void LoadMajorCities()
        {
            ddlMajorCities.Items.Clear(); // Clear existing items first
            ddlMajorCities.Items.Add(new ListItem("Select City", "0")); // Add default item with "0" value

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DISTINCT [CityName] FROM [MajorCities] ORDER BY [CityName]";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cityName = reader["CityName"].ToString();
                            ddlMajorCities.Items.Add(new ListItem(cityName, cityName));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the company logo to the server and returns the relative path
        /// </summary>
        /// <param name="fileUpload">The FileUpload control containing the image</param>
        /// <returns>The relative path of the saved image</returns>
        private string SaveCompanyImage(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.HasFile)
                {
                    // Generate unique filename to prevent conflicts
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);

                    // Get the physical path of the Images folder
                    string uploadsPath = Server.MapPath("~/Images");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    // Combine path and save file
                    string filePath = Path.Combine(uploadsPath, fileName);
                    fileUpload.SaveAs(filePath);

                    // Return relative path for database storage
                    return "Images/" + fileName;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving image: {ex.Message}");
            }
        }

        /// <summary>
        /// Fills the form with existing job data when editing
        /// </summary>
        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                Session["title"] = "Edit Job";
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
                            // Populate fields with job details
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

                            // Handle Province and City selection
                            string province = sdr["Province"].ToString();
                            string majorCity = sdr["MajorCities"].ToString();

                            // Set Province
                            if (!string.IsNullOrEmpty(province))
                            {
                                ListItem provinceItem = ddlProvinces.Items.FindByValue(province);
                                if (provinceItem != null)
                                {
                                    ddlProvinces.SelectedValue = province;
                                }
                            }

                            // Set Major City
                            if (!string.IsNullOrEmpty(majorCity))
                            {
                                ListItem cityItem = ddlMajorCities.Items.FindByValue(majorCity);
                                if (cityItem != null)
                                {
                                    ddlMajorCities.SelectedValue = majorCity;
                                }
                                else
                                {
                                    // If the city doesn't exist in the dropdown, add it
                                    ddlMajorCities.Items.Add(new ListItem(majorCity, majorCity));
                                    ddlMajorCities.SelectedValue = majorCity;
                                }
                            }
                            else
                            {
                                ddlMajorCities.SelectedValue = "0"; // Select the default option
                            }
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

        /// <summary>
        /// Handles the Add/Update button click event
        /// </summary>
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
                            // Update existing job
                            query = @"UPDATE Jobs SET Title = @Title, NoOfPost = @NoOfPost, Description = @Description, Qualification = @Qualification,
                                     Experience = @Experience, Specialization = @Specialization, LastDateToApply = @LastDateToApply, 
                                     Salary = @Salary, JobType = @JobType, CompanyName = @CompanyName, Website = @Website, 
                                     Email = @Email, Address = @Address, Province = @Province, MajorCities = @MajorCities";

                            if (CompanyLogo.HasFile)
                            {
                                imagePath = SaveCompanyImage(CompanyLogo);
                                query += ", CompanyImage = @CompanyImage";
                            }

                            query += " WHERE JobId = @JobId";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                        }
                        else
                        {
                            // Insert new job
                            query = @"INSERT INTO Jobs (Title, NoOfPost, Description, Qualification, Experience, Specialization, LastDateToApply, 
                                     Salary, JobType, CompanyName, CompanyImage, Website, Email, Address, Province, MajorCities, CreateDate) 
                                     VALUES (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, 
                                     @Salary, @JobType, @CompanyName, @CompanyImage, @Website, @Email, @Address, @Province, @MajorCities, @CreateDate)";

                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                            if (CompanyLogo.HasFile)
                            {
                                imagePath = SaveCompanyImage(CompanyLogo);
                            }
                        }

                        // Add common parameters
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
                        cmd.Parameters.AddWithValue("@MajorCities", ddlMajorCities.SelectedValue);

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
            ddlJobType.ClearSelection();
            txtCompany.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlProvinces.ClearSelection();
            ddlMajorCities.ClearSelection();
        }

   
        private bool IsValidExtension(string fileName)
        {
            string[] validFileExtensions = { ".jpg", ".jpeg", ".png" };
            return validFileExtensions.Contains(Path.GetExtension(fileName).ToLower());
        }
    }
}

/*Code Attribution:
 * Original Source: Online Job Portal using ASP.NET C# and SQL Server
 * Source URL: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creator: Tech Tips Unlimited
 */