using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication1
{
    public partial class loginform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from Table1 where Username='" + TextBoxUser.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = (Int32)com.ExecuteScalar();
            conn.Close();
            if (temp > 0)
            {
                conn.Open();
                string checkPass = "select password from Table1 where Username='" + TextBoxUser.Text + "'";
                SqlCommand passcom = new SqlCommand(checkPass, conn);
                string password = (string)passcom.ExecuteScalar();
                password=password.Replace(" ", "");
               

                if (password == TextBoxPass.Text)
                {
                    Session["New"] = TextBoxUser.Text;
                    Response.Write("Password is correct");
                }
                else
                {
                    Response.Write("Password is incorrect");
                }
                conn.Close();
            }
            else {
                Response.Write("Invalid Username");

            }
            
        }
    }
}