using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PrimeCode_XBCAD7319.User
{
    public partial class job_listing : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //user needs to be logged in before the filter pages opens
            if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
                return;
            }
            //will show page once loggedin
            if (!IsPostBack)
            {
                // Load the initial job list when the page first loads
                LoadInitialJobList();

                // Check filter usage status from the database
                CheckFilterUsageStatus();

                // Load provinces and cities
                LoadProvinces();
                LoadMajorCities();
            }
        }

        private void LoadProvinces()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Updated query to select from Province table instead of Jobs table
                string query = "SELECT [ProvinceName] FROM [Province] ORDER BY [ProvinceName]";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlProvinces.Items.Clear();
                        ddlProvinces.Items.Add(new ListItem("Select Province", "0"));
                        while (reader.Read())
                        {
                            string provinceName = reader["ProvinceName"].ToString();
                            ddlProvinces.Items.Add(new ListItem(provinceName, provinceName));
                        }
                    }
                }
            }
        }

        private void LoadMajorCities()
        {
            ddlMajorCities.Items.Clear();
            ddlMajorCities.Items.Add(new ListItem("Select Major City", "0"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT CityName FROM MajorCities ORDER BY CityName";
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

        protected void ddlProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMajorCities();
        }

        //code to load find a job page 
        private void LoadInitialJobList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = "SELECT JobId, Title, Salary, JobType, CompanyName, CompanyImage, Province, MajorCities, CreateDate FROM Jobs WHERE 1=1";
            showJobList(query, parameters);
        }

        //code to check if a user has clicked the filter button more then once 
        private void CheckFilterUsageStatus()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT FilterCount, HasPaid FROM UserFilterTracking WHERE UserId = @UserId";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["FilterCount"] = reader["FilterCount"];
                        Session["HasPaid"] = reader["HasPaid"];
                    }
                    else
                    {
                        // Initialize user filter tracking if not found
                        Session["FilterCount"] = 0;
                        Session["HasPaid"] = false;

                        // Insert a new record for the user
                        InsertUserFilterTracking(userId);
                    }
                    reader.Close();
                }
            }
        }
        //tracks how many filter search a user has done
        private void InsertUserFilterTracking(int userId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO UserFilterTracking (UserId, FilterCount, HasPaid) VALUES (@UserId, 0, 0)";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //shows the job list 
        private void showJobList(string query = null, List<SqlParameter> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                query = query ?? "SELECT JobId, Title, Salary, JobType, CompanyName, CompanyImage, Province, MajorCities, CreateDate FROM Jobs";
                using (cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                }
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobCount.Text = GetJobCountMessage(dt.Rows.Count);
        }

        /*Code Attribute for JobList
        * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
        * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
        */
        //code for the total job list depending on how many are in the databse 
        private string GetJobCountMessage(int count)
        {
            if (count > 1)
            {
                return $"Total <b>{count}</b> jobs found";
            }
            else if (count == 1)
            {
                return $"Total <b>{count}</b> job found";
            }
            else
            {
                return "No jobs found";
            }
        }

        /*Code Attribute for JobList
        * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
        * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
        */
        //code for the filter button so that it can filter the job as well as redirect the user to payment page for more then one filter search
        protected void lbFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the user ID and username
                int userId = Convert.ToInt32(Session["UserId"]);
                string username = Session["Username"].ToString();

                // Check if the user has paid (is in the PaymentSessions table)
                bool hasPaid = IsUserInPaymentSessions(username);

                // If user has not paid and the filter count exceeds the limit, redirect to payment page
                if (!hasPaid)
                {
                    if (Session["FilterCount"] == null)
                    {
                        Session["FilterCount"] = 0;
                    }

                    int filterCount = (int)Session["FilterCount"];
                    filterCount++;
                    Session["FilterCount"] = filterCount;

                    if (filterCount > 1)
                    {
                        // Update the FilterCount in the database
                        UpdateFilterCount(userId, filterCount);
                        Response.Redirect("~/User/Payment.aspx");
                        return;
                    }

                    // Update the FilterCount in the database
                    UpdateFilterCount(userId, filterCount);
                }

                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "SELECT JobId, Title, Salary, JobType, CompanyName, CompanyImage, Province, MajorCities, CreateDate FROM Jobs WHERE 1=1";

                if (ddlProvinces.SelectedValue != "0")
                {
                    query += " AND Province = @Province";
                    parameters.Add(new SqlParameter("@Province", ddlProvinces.SelectedValue));
                }

                if (ddlMajorCities.SelectedValue != "0")
                {
                    query += " AND MajorCities = @MajorCities";
                    parameters.Add(new SqlParameter("@MajorCities", ddlMajorCities.SelectedValue));
                }

                string jobType = SelectedCheckBox();
                if (!string.IsNullOrEmpty(jobType))
                {
                    query += " AND JobType IN (" + jobType + ")";
                }

                string postedDate = SelectedCheckButton();
                if (!string.IsNullOrEmpty(postedDate))
                {
                    query += $" AND {postedDate}";
                }

                showJobList(query, parameters);
                RBSelectedColourChange();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //will update the filter account depending if user has paid or not
        private void UpdateFilterCount(int userId, int filterCount)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE UserFilterTracking SET FilterCount = @FilterCount WHERE UserId = @UserId";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@FilterCount", filterCount);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //code to check if payment is done and they can have unlimited filter searches
        private bool IsUserInPaymentSessions(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM PaymentSessions WHERE Username = @Username";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //code for the checked boxes for joy type
        private string SelectedCheckBox()
        {
            List<string> jobTypes = new List<string>();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    jobTypes.Add("'" + item.Text + "'");
                }
            }
            return string.Join(",", jobTypes);
        }

        //code for the posted within checkboxes to ensure the date they pick can filter out the jobs uploaded
        private string SelectedCheckButton()
        {
            DateTime today = DateTime.Today;
            string postedDateCondition = string.Empty;

            switch (CheckBoxList2.SelectedValue)
            {
                case "1":
                    postedDateCondition = $"CONVERT(DATE, CreateDate) = '{today:yyyy-MM-dd}'";
                    break;
                case "2":
                    postedDateCondition = $"CONVERT(DATE, CreateDate) BETWEEN '{today.AddDays(-2):yyyy-MM-dd}' AND '{today:yyyy-MM-dd}'";
                    break;
                case "3":
                    postedDateCondition = $"CONVERT(DATE, CreateDate) BETWEEN '{today.AddDays(-3):yyyy-MM-dd}' AND '{today:yyyy-MM-dd}'";
                    break;
                case "4":
                    postedDateCondition = $"CONVERT(DATE, CreateDate) BETWEEN '{today.AddDays(-5):yyyy-MM-dd}' AND '{today:yyyy-MM-dd}'";
                    break;
                case "5":
                    postedDateCondition = $"CONVERT(DATE, CreateDate) BETWEEN '{today.AddDays(-10):yyyy-MM-dd}' AND '{today:yyyy-MM-dd}'";
                    break;
                default:
                    postedDateCondition = string.Empty;
                    break;
            }

            return postedDateCondition;
        }

        /*Code Attribute for JobList
        * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
        * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
        */
        //code to clear the filter and show all the job
        protected void lbRest_Click(object sender, EventArgs e)
        {
            CheckBoxList1.ClearSelection();
            CheckBoxList2.ClearSelection();
            ddlProvinces.ClearSelection();
            ddlMajorCities.ClearSelection();
            ddlProvinces.SelectedValue = "0";
            ddlMajorCities.SelectedValue = "0";
            LoadInitialJobList();
        }

        /*Code Attribute for JobList
        * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
        * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
        */
        protected void RBSelectedColourChange()
        {
            foreach (ListItem item in CheckBoxList2.Items)
            {
                item.Attributes.CssStyle.Remove("background-color");
                if (item.Selected)
                {
                    //applies a background colour when a check box is clicked
                    item.Attributes.CssStyle.Add("background-color", "white");
                }
            }
        }

        /*Code Attribute for JobList
        * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
        * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
        */
        //to get the company image to display
        protected string GetImageUrl(object url)
        {
            if (url == null || string.IsNullOrEmpty(url.ToString()))
            {
                return ResolveUrl("~/public/images/No_image.jpg");
            }
            else
            {
                return ResolveUrl($"~/{url}");
            }
        }

        /*Code Attribute for JobList
         * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
         * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
         */
        //for the job listing to have the date the job was posted to be display correctly
        public static string RelativeDate(DateTime theDate)
        {
            TimeSpan timeSpan = DateTime.Now - theDate;

            if (timeSpan.TotalSeconds < 60)
                return $"{(int)timeSpan.TotalSeconds} seconds ago";

            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minutes ago";

            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hours ago";

            if (timeSpan.TotalDays == 1)
                return "yesterday";

            if (timeSpan.TotalDays < 30)
                return $"{(int)timeSpan.TotalDays} days ago";

            if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)} months ago";

            return $"{(int)(timeSpan.TotalDays / 365)} years ago";
        }
    }
}