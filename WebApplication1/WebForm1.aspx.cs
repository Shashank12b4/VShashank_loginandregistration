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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (IsPostBack) {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from Table1 where Username='"+TextBoxUser.Text+"'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = (Int32)com.ExecuteScalar();
                if (temp!=0) {
                    Response.Write("registration with that username is already done");
                }
                conn.Close();
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            try
            {
                Guid newGUID = Guid.NewGuid();

                conn.Open();
                string checkuser = "select count(*) from Table1 where Username='" + TextBoxUser.Text + "'";
                SqlCommand com1 = new SqlCommand(checkuser, conn);
                int temp = (Int32)com1.ExecuteScalar();
                if (temp == 0)
                {
                    string insertQuery = "insert into Table1 (ID,Username,email,Password,Country) values(@ID,@Uname,@email,@password,@country)";
                    SqlCommand com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@ID", newGUID.ToString());
                    com.Parameters.AddWithValue("@Uname", TextBoxUser.Text);
                    com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                    com.Parameters.AddWithValue("@password", TextBoxPass.Text);
                    com.Parameters.AddWithValue("@country", DropDownListCountry.SelectedItem.ToString());
                    com.ExecuteNonQuery();
                    Response.Redirect("loginform.aspx");
                }
                

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());

            }
            finally {
                conn.Close();
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginform.aspx");
        }
    }
}