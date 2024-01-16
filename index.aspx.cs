using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System;


using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration.Provider;


namespace WebApp2
{
    public partial class index : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Your logic for dynamically setting the master page
            if (Session["CHANGE_MASTERPAGE"] != null && Session["CHANGE_MASTERPAGE2"] == null)
            {
                this.MasterPageFile = Session["CHANGE_MASTERPAGE"].ToString();
            }

            if (Session["CHANGE_MASTERPAGE2"] != null && Session["CHANGE_MASTERPAGE"] == null)
            {
                this.MasterPageFile = Session["CHANGE_MASTERPAGE2"].ToString();
            }
            if (Session["CHANGE_MASTERPAGE2"] == null && Session["CHANGE_MASTERPAGE"] == null)
            {
                this.MasterPageFile = "~/MasterPage1.Master";
            }
        }
        private void BindProductData()
        {
            // Connect to the database and fetch product data


            string strConnectionString = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM All_Products", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //// Bind data to the Repeater
                productRepeater.DataSource = dt;
                productRepeater.DataBind();
            }
        }
        protected string GetStarIcons(int rating)
        {
            StringBuilder stars = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                if (i < rating)
                {
                    // Display a filled star if i is less than the rating
                    stars.Append("<ion-icon name=\"star\"></ion-icon>");
                }
                else
                {
                    // Display an outline star if i is greater than or equal to the rating
                    stars.Append("<ion-icon name=\"star-outline\"></ion-icon>");
                }
            }

            return stars.ToString();
        }

    }
}

