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
    public partial class password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
                string se = "select password from regi where id=" + Session["uid"] + "";
                SqlCommand cmd = new SqlCommand(se, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr["password"].ToString();
                }
                con.Close();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;

            string str = "update regi set password ='" + TextBox3.Text + "' where id=" + Session["uid"] + "";
            SqlCommand smd = new SqlCommand(str, con);
            con.Open();
            int j = smd.ExecuteNonQuery();
            con.Close();
            if(j==1)
            {
                Label1.Text = "Password Updated";
            }
            else
            {
                Label1.Text = "Not Update";
            }

        }
    }
}