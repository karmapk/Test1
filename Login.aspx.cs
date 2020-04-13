using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AainaSalonWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.ToString();
            String password = TextBox2.Text;

            string pass = encryption(password);
            Label1.Text = pass;

            if (username.Length > 0 && password.Length > 0)
            {
                string constr = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                SqlConnection con = new SqlConnection(constr);
                String passwords = encryption(password);
                con.Open();

                String search = "Select * from UserAccount where (UserName='" + username + "');";
                SqlCommand cmds = new SqlCommand(search, con);
                SqlDataReader sqldrs = cmds.ExecuteReader();
     
                if (sqldrs.Read())
                {
                    String passed = (string)sqldrs["Password"];
                    Label1.Text = "UserName already taken";
                }
                else
                {
                    try
                    {
                        string sql = "Insert into UserAccount(UserName,Password) VALUES('" + username + "','" + passwords + "');";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        String Message = "Saved Successfully";
                        Label1.Text = Message.ToString();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                       // Response.Redirect("Index.aspx");
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.ToString();
                    }
                    con.Close();
                }
            }
            else
            {
                String Message = "UserName or Password is Empty";
                Label1.Text = Message.ToString();
            }
        }

        private string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encript;
            UTF8Encoding encode = new UTF8Encoding();
            encript = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encript.Length; i++)
            {
                encryptdata.Append(encript[i].ToString());
            }
            return encryptdata.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String username = TextBox1.Text.ToString();
            String password = TextBox2.Text;
            string con = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
            //string con=ConfigurationManager.ConnectionStrings["constr"].ToString();
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string passwords = encryption(password);
            String query = "select UserName,Password from UserAccount Where(UserName='" + username + "')AND(Password='" + passwords + "');";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader sqldr = cmd.ExecuteReader();
            if (sqldr.Read())
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Label1.Text = "User Not found";
            }
            connection.Close();
        }
    }
}