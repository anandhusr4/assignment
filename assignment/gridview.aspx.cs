using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace assignment
{
    public partial class gridview : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid_fun();
        }
        public void Grid_fun()
        {
            string st = " select * from regi";
            SqlDataAdapter da = new SqlDataAdapter(st, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Grid_fun();
        }
    }
}