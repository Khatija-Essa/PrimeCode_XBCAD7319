using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {//user need to be logged in before they can go to this page
            if (Session["userId"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //display all the counts
            if (!IsPostBack)
            {
                Users();
                Jobs();
                AppliedJobs();
                CountactCount();
                Partner();
            }
        }
        //display the count of how many people have contacted the users
        private void CountactCount()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sda = new SqlDataAdapter("Select Count (*) from Contact", con);
                dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    Session["Contact"] = dt.Rows[0][0];
                }
                else
                {
                    Session["Contact"] = 0;
                }
            }


        }
        //display the amount of partners registered for thie job
        private void Partner()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sda = new SqlDataAdapter("Select Count (*) from Partner", con);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["Partner"] = dt.Rows[0][0];
                }
                else
                {
                    Session["Partner"] = 0;
                }
            }
        }
        //display how many user applied for the job
        private void AppliedJobs()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sda = new SqlDataAdapter("Select Count (*) from AppliedJobs", con);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["AppliedJobs"] = dt.Rows[0][0];
                }
                else
                {
                    Session["AppliedJobs"] = 0;
                }
            }
        }
        //display the count of the jobs uploaded on this website
        private void Jobs()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sda = new SqlDataAdapter("Select Count (*) from Jobs", con);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["Jobs"] = dt.Rows[0][0];
                }
                else
                {
                    Session["Jobs"] = 0;
                }
            }
        }
        //display the count of user registered on the wbesite
        private void Users()
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:primecode.database.windows.net,1433;Initial Catalog=JobConnector;Persist Security Info=False;User ID=primecode;Password=xbcad@7319;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sda = new SqlDataAdapter("Select Count (*) from [User]", con);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["Users"] = dt.Rows[0][0];
                }
                else
                {
                    Session["Users"] = 0;
                }
            }
        }
    }
}
/*Code Attribute for Dashboard
 * Source: https://youtube.com/playlist?list=PL4HegTSNb5KEuVLeB9dDvENr2lqbsSSK3&si=7Gi5mDIHcPu5xANP
 * Creater : Tech Tips Ulimited- Online Job Portal using ASP.NET C# and Sql Server
 */