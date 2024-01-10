using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;



namespace WebApp2
{
    public partial class ProductDetails : System.Web.UI.Page { 
        //declare a new Product class
        Product prod = null;

        //retrieve connection info from web.config
        string constr = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve product details based on the product ID from the query string
            Product aProd = new Product();

            //request ProdID from QueryString (PostBackURL)
            string prodID = Request.QueryString["ProdID"].ToString();


            prod = aProd.GetProduct(prodID);

            // Set the labels with product details
            lblProductName.Text = prod.ProductName;
            lblProductDesc.Text = prod.ProductDescription;
            lblProductPrice.Text = prod.Price.ToString("C");
            lblProductCategory.Text = prod.ProductCategory;
        }


        // Helper method to generate star ratings dynamically
        private string GenerateStarRating(int rating)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rating; i++)
            {
                sb.Append("<ion-icon name=\"star\"></ion-icon>");
            }
            for (int i = rating; i < 5; i++)
            {
                sb.Append("<ion-icon name=\"star-outline\"></ion-icon>");
            }
            return sb.ToString();
        }

        // Helper method to generate product status dynamically
        private string GenerateStatus(string category)
        {
            // Example: If category is "Electronics", return "In Stock: 15"
            // You can adjust this based on your needs.
            return $"In Stock: {GetStockCountForCategory(category)}";
        }

        private int GetStockCountForCategory(string category)
        {
            // Your logic to get stock count for a specific category
            // This is just a placeholder; you'll need to implement your own logic.
            return 15;
        }
    }
}