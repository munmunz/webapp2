using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2
{
    public partial class MasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Search.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Guid newGUID = Guid.NewGuid();
            bool exists = false;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM REGISTRATION WHERE Email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txt_RegEmail.Text);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    Response.Write("<script>alert('Sorry, Email is already taken!');</script>");
                    return; // Exit the method if email exists
                }

                string insertQuery = "INSERT INTO REGISTRATION (Id, First_Name, Last_Name, Email, Password) " +
                    "VALUES (@id, @first, @last, @email, @password)";

                using (SqlCommand com = new SqlCommand(insertQuery, conn))
                {
                    com.Parameters.AddWithValue("@password", txt_RegPassword.Text);
                    com.Parameters.AddWithValue("@id", newGUID.ToString());
                    com.Parameters.AddWithValue("@email", txt_RegEmail.Text);
                    com.Parameters.AddWithValue("@first", txt_FirstName.Text);
                    com.Parameters.AddWithValue("@last", txt_LastName.Text);

                    com.ExecuteNonQuery();
                }

                Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");
            }

            txt_FirstName.Text = "";
            txt_LastName.Text = "";
            txt_RegEmail.Text = "";
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session["Email"] = txt_Email.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString))
            {
                conn.Open();

                string checkuser = "SELECT COUNT(*) FROM REGISTRATION WHERE Email = @Email";
                using (SqlCommand com = new SqlCommand(checkuser, conn))
                {
                    com.Parameters.AddWithValue("@Email", txt_Email.Text);

                    int temp = Convert.ToInt32(com.ExecuteScalar());

                    if (temp == 1)
                    {
                        string checkPasswordQuery = "SELECT Password FROM REGISTRATION WHERE Email = @Email2";
                        using (SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, conn))
                        {
                            pwcomm.Parameters.AddWithValue("@Email2", txt_Email.Text);
                            string password = pwcomm.ExecuteScalar().ToString();

                            // Here, you can implement password verification if needed
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Password or UserName is not correct')</script>");
                    }

                    Response.Write("<script>alert('Successfully logged in ');</script>");
                }
            }

            txt_Email.Text = ""; // Clears textbox after login
        }

    }
}