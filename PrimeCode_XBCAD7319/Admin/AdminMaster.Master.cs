using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PrimeCode_XBCAD7319.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=labVMH8OX\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False");
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}