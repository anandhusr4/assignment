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
    public partial class p1aspx : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"server=LOGAN\SQLEXPRESS;database=abc;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Panel2.Visible = true;
            Label1.Text = TextBox1.Text;
            Label2.Text = TextBox2.Text;
            Label3.Text = TextBox5.Text;
            Label4.Text = TextBox3.Text;
            Label5.Text = TextBox4.Text;
            Label6.Text = RadioButtonList1.SelectedItem.Text;
            Label7.Text = DropDownList1.SelectedItem.Text;

            String s = "";
            for(int i=0;i<CheckBoxList1.Items.Count;i++)
            {
                if(CheckBoxList1.Items[i].Selected)
                {
                    s = s + CheckBoxList1.Items[i].Text + ",";
                }
            }
            Label8.Text = s;

            string p = "~/photo/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            Image1.ImageUrl = p;

            Label9.Text = TextBox6.Text;
            Label10.Text = TextBox7.Text;
            Label11.Text = TextBox8.Text;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string p1 = "~/photo/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p1));

            String s1 = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    s1 = s1 + CheckBoxList1.Items[i].Text + ",";
                }
            }
            string str = "insert into regi values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox5.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + s1 + "','" + p1 + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i1 = cmd.ExecuteNonQuery();
            con.Close();
            if(i1==1)
            {
                Label12.Text = "Inserted";
            }
        }
    }
}