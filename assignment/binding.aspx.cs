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
    public partial class binding : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {

                string sr = "select id,name from regi";
                
                SqlDataAdapter da = new SqlDataAdapter(sr, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sr = "select * from regi where id=" + DropDownList1.SelectedItem.Value + "";
            Label1.Text = DropDownList1.SelectedItem.Text;
            Label2.Text = DropDownList1.SelectedItem.Value;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s= "select * from regi";
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}