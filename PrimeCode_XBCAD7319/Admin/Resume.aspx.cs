using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class Resume : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //checks the user is logged in before redirecting them to the page
            if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //displays all the people who have applied for the job and what job it is 
            if (!IsPostBack)
            {
                ShowAppliedJob();
            }
        }

        //looks at the user and job table to display the job title, jobappliedid, company name, job id, and the user name,email,cv,resume,transcript,id, matric and mobile. 
        private void ShowAppliedJob()
        {
            string query = string.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                query = @"Select Row_Number() over(Order by(Select 1)) as [Sr.No], aj.AppliedJobId, j.CompanyName, aj.JobId, j.Title, u.Mobile,
                    u.Name, u.Email, u.Resume, u.Transcript, u.ID, u.Matric, u.CV from AppliedJobs aj
                    inner join [User] u on aj.UserId = u.UserId
                    inner join Jobs j on aj.JobId = j.JobId ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        //to get more then one table
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAppliedJob();
        }

       


    }
}

/*Code Attribute for Resume
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */