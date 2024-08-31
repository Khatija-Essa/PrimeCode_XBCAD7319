﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class Resume : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {//checks the user is logged in before redirecting them to the page
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
            using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
            {
                query = @"Select Row_Number() over(Order by(Select 1)) as [Sr.No], aj.AppliedJobId, j.CompanyName, aj.JobId, j.Title, u.Mobile,
                        u.Name, u.Email, u.Resume, u.Transcript, u.ID, u.Matric from AppliedJobs aj
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

     //to delete a row 
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int appliedjobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                using (SqlConnection con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False"))
                {
                    cmd = new SqlCommand("Delete from AppliedJobs where AppliedJobId = @id", con);
                    cmd.Parameters.AddWithValue("@id", appliedjobId);
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Delete successful";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Could not delete";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                    GridView1.EditIndex = -1;
                    ShowAppliedJob();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        //to click on a row and be redirect to the job list page to see what job it was
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to view job details";
        }
        //to click on a row and be redirect to the joblist page
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                if(row.RowIndex == GridView1.SelectedIndex)
                {
                    HiddenField jobId = (HiddenField)row.FindControl("hdnJobId");
                    Response.Redirect("JobList.aspx?id=" + jobId.Value);
                }
                else
                {

                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row";
                }
            }
        }
    }
}
/*Code Attribute for Resume
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */