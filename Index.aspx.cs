using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AainaSalonWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView();
        }

        private void GridView()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from a_customers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text != null && txtMobile.Text != null && txtEmail.Text != null && txtCity.Text != null && txtJob.Text != null)
            {

                string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Cust_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Name", txtName.Text);
                cmd.Parameters.AddWithValue("Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("City", txtCity.Text);
                cmd.Parameters.AddWithValue("Job", txtJob.Text);

                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    lblmsg.Text = "Data Inserted Succesfully ";
                    //lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                }

                txtName.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtCity.Text = "";
                txtJob.Text = "";

                con.Close();
                GridView();
            }
            else
            {
                lblmsg.Text = "Please insert required data";
            }
        }
    }
}