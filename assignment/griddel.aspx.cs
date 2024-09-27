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
    public partial class griddel : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            grid_fun();

        }
        public void grid_fun()
        {
            string s = "select * from regi";
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string del = "delete from regi where id='" + getid + "'";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            grid_fun();

        }
    }
}