using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve the session variable
            txtSearch.Text = Session["Search"].ToString();

            //PostBack allows the search function to run again when another string is entered into the textbox.
            //if PostBack is not true/enabled, the method will only run one time and not run again if a new
            //string is entered.
            if (!IsPostBack)
            {
                //retrieve connection info from web.config
                string strConnectionString = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //open the connection
                myConnect.Open();

                //create search command to retrieve data from table
                string checksearch = "SELECT COUNT(*) FROM [All_Products] WHERE ProductName LIKE @search OR ProductCategory LIKE @search";
                SqlCommand com = new SqlCommand(checksearch, myConnect);

                //declare @search
                com.Parameters.AddWithValue("@search", txtSearch.Text);
                com.Parameters["@search"].Value = "%" + txtSearch.Text + "%";

                //use temp to create a fucntion
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

                //close the connection
                myConnect.Close();

                //if the record exists
                if (temp > 0)
                {
                    string strCommandText = "SELECT *";
                    strCommandText += " FROM All_Products WHERE ProductName LIKE @productname OR ProductCategory LIKE @productcategory";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                    //declare cmd parameters for title and author to be dispayed
                    cmd.Parameters.Add("@productname", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@productname"].Value = "%" + txtSearch.Text + "%";
                    cmd.Parameters.Add("@productcategory", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@productcategory"].Value = "%" + txtSearch.Text + "%";

                    //open the connection
                    myConnect.Open();

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ProductName");
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();

                    //close the connection
                    myConnect.Close();
                }

                //else record does not exist
                else
                {
                    lblnoresult.Visible = true;
                }
            }
        }

    
    }
}