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
   
    public partial class abc : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string sel ="select count(id) from regi where username='"+TextBox1.Text+"' and password='"+TextBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if(cid=="1")
            {
                string sei = "select id from regi where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sei, con);
                con.Open();
                string id = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;

                Response.Redirect("new.aspx");
            }
            else
            {
                Label1.Text = "Invalid username and password";
            }
        }
    }
}