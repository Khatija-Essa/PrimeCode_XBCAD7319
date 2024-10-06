using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["userId"] != null && Session["username"] != null)
                    {
                        if (litUserName != null)
                            litUserName.Text = $"Welcome : {Session["username"]}";

                        if (btnLogout != null)
                            btnLogout.Visible = true;

                        LoadNotifications();
                    }
                    else
                    {
                        if (btnLogout != null)
                            btnLogout.Visible = false;

                        SetNotificationCount("0");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in Page_Load: " + ex.Message);
            }
        }

        private void LoadNotifications()
        {
            try
            {
                var notificationData = GetNotifications();
                UpdateNotificationUI(notificationData);
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in LoadNotifications: " + ex.Message);
            }
        }

        private void UpdateNotificationUI(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    int count = dt.Rows.Count;
                    SetNotificationCount(count.ToString());

                    if (r1 != null)
                    {
                        r1.DataSource = dt;
                        r1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in UpdateNotificationUI: " + ex.Message);
            }
        }

        private void SetNotificationCount(string count)
        {
            if (notification1 != null)
                notification1.Text = count;
            if (notification2 != null)
                notification2.Text = count;
        }

        private static DataTable GetNotifications()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Username, [Plan] FROM PaymentSessions WHERE PaymentMade = 'yes' ORDER BY CreatedAt DESC", con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in GetNotifications: " + ex.Message);
            }
            return dt;
        }

        /*Code Attribute for AdminMaster(paymet notifcation)          
        *Source: https://youtu.be/jxGhb5gyP2s?si=YvFLFWCmjsHq6vJ4          
        *Creater : Amit Andipara         
        */
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("../User/Default.aspx");
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in btnLogout_Click: " + ex.Message);
            }
        }

        protected void r1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton clearButton = e.Item.FindControl("ClearButton") as LinkButton;
                    if (clearButton != null)
                    {
                        clearButton.Attributes["data-index"] = e.Item.ItemIndex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in r1_ItemDataBound: " + ex.Message);
            }
        }

        [WebMethod]
        public static void UpdateNotificationCount(int newCount)
        {
            try
            {
                if (HttpContext.Current?.Session != null)
                {
                    HttpContext.Current.Session["NotificationCount"] = newCount;
                }
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine("Error in UpdateNotificationCount: " + ex.Message);
            }
        }
    }
}