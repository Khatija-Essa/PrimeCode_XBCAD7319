using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class JobList : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;

        protected void Page_PreRender(object sender, EventArgs e)
        {//makes sure user is logged in first
            if (Session["userId"] ==null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //display the job list
            if(!IsPostBack)
            {
                ShowJob();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJob();
        }
        //gets the data from the databse and has it display in a table
        private void ShowJob()
        {
            string query = string.Empty;
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                query = @"Select Row_Number() over(Order by(Select 1)) as [Sr.No], JobId, Title,NoOfPost, Description, Qualification, Experience, 
                        LastDateToApply, CompanyName, Province, CreateDate from Jobs  ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (Request.QueryString["id"] != null)
                {
                    linkback.Visible = true;
                }

            }
        }
        //to have the ablitiy to have more then one table to display the data
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
        }
        //to delete a job
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int jobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    cmd = new SqlCommand("Delete from Jobs where JobId = @id", con);
                    cmd.Parameters.AddWithValue("@id", jobId);
                    con.Open(); 
                    int r = cmd.ExecuteNonQuery();
                    if(r> 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Deleted Successfully.";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Could not delete";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    
                    GridView1.EditIndex = -1;
                    ShowJob();
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //to edit a job
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "EditJob")
            {
                Response.Redirect("../Company/NewJob.aspx?id=" + e.CommandArgument.ToString());
            }
        }
        //binds this page the the resume page so admin can click on a user that applied for a job on the resuem page and it will show the job on the job list page
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ID = e.Row.RowIndex.ToString();
                if (Request.QueryString["id"] != null)
                {
                    int jobId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values[0]);
                    if(jobId == Convert.ToInt32(Request.QueryString["id"]))
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#A5C8D4");
                    }
                }
            }
        }
    }
}
/*Code Attribute for Joblist
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */