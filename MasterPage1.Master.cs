using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salt_Password_Sample;
using Hash = Salt_Password_Sample.Hash;

namespace WebApp2
{
    public partial class MasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {      

        }


        protected void Page_PreInit(object sender, EventArgs e)
        {

            // Your logic for the PreInit event
            if (Session["CHANGE_MASTERPAGE"] != null && Session["CHANGE_MASTERPAGE2"] == null)
            {
                this.MasterPageFile = Session["CHANGE_MASTERPAGE"].ToString();
            }

            if (Session["CHANGE_MASTERPAGE2"] != null && Session["CHANGE_MASTERPAGE"] == null)
            {
                this.MasterPageFile = Session["CHANGE_MASTERPAGE2"].ToString();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Search.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Guid newGUID = Guid.NewGuid();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString);

            conn.Open();

            bool exists = false;

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [REGISTRATION] WHERE Email = @email", conn))
            {
                //checks if the email that the user has entered exists in the database table
                cmd.Parameters.AddWithValue("Email", txt_RegEmail.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            //if the email exists, send an alert
            if (exists)
            {
                Response.Write("<script>alert('Sorry, Email is already taken!');</script>");
            }

            //else, insert 
            else
            {
                string insertQuery = "INSERT INTO REGISTRATION (Id, First_Name, Last_Name, Email, Password) " +
                    "values (@id, @first, @last, @email, @password)";

                SqlCommand com = new SqlCommand(insertQuery, conn);
                string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                com.Parameters.AddWithValue("@password", ePass);
                com.Parameters.AddWithValue("@id", newGUID.ToString());
                com.Parameters.AddWithValue("@email", txt_RegEmail.Text);
                com.Parameters.AddWithValue("@first", txt_FirstName.Text);
                com.Parameters.AddWithValue("@last", txt_LastName.Text);

                com.ExecuteNonQuery();

                Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");
            }

            conn.Close();

            txt_FirstName.Text = "";
            txt_LastName.Text = "";
            txt_RegEmail.Text = "";
        }


        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session["Email"] = txt_Email.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString);

            conn.Open();

            string checkuser = "SELECT COUNT(*) FROM REGISTRATION WHERE Email = @email";
            SqlCommand com = new SqlCommand(checkuser, conn);
            com.Parameters.AddWithValue("@email", txt_Email.Text);

            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            conn.Close();

            if (temp == 1)//checks if email exists inside DB
            {
                conn.Open();

                string checkPasswordQuery = "SELECT Password FROM REGISTRATION WHERE Email = @email2";

                SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, conn);
                pwcomm.Parameters.AddWithValue("@email2", txt_Email.Text);
                string password = pwcomm.ExecuteScalar().ToString();
                bool flag = Hash.VerifyHash(txt_Password.Text, "SHA512", password);//verifies password through hash function

                if (flag == true)
                {
                    Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                    Session["CHANGE_MASTERPAGE2"] = null;
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
            }

            txt_Email.Text = ""; //clears textbox after login
        }
    }
}

