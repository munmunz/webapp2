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
    public partial class BestSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataSet is an in-memory cache of data retrieved from a data source
            //step 1: create Dataset with a GET method
            DataSet datawomen = GetDataWomen();
          

            //DataSource is used to pull the data from the database and populate them
            //step 8: pull data using DataSource
            Repeater1.DataSource = datawomen;
          

            //step 9: bind the data to the repeater
            Repeater1.DataBind();
        
        }

        private DataSet GetDataWomen()
        {
            //step 2: retrieve connection info from web.config
            string ShoppingDB = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;

            //step 3: define a connection to the database
            using (SqlConnection conn = new SqlConnection(ShoppingDB))
            {
                //step 4: create a command to retrieve data from a table in your database
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_Women", conn);

                //step 5: create a new DataSet
                DataSet datawomen = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                cmd.Fill(datawomen);

                //step 7: return
                return datawomen;
            }
        }

     

    }
}