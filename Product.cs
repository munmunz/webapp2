using System;
using System.Data.SqlClient;
using System.Configuration;

public class Product
{
    private string _id;
    private string _productName;
    private string _productDescription;
    private decimal _price;
    private int _rating;
    private string _productImage;
    private string _productCategory;

    private string _connStr = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;

    public Product()
    {
    }

    public Product(string id, string productName, string productDescription, decimal price, int rating, string productImage, string productCategory)
    {
        _id = id;
        _productName = productName;
        _productDescription = productDescription;
        _price = price;
        _rating = rating;
        _productImage = productImage;
        _productCategory = productCategory;
    }

    public string ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    public string ProductDescription
    {
        get { return _productDescription; }
        set { _productDescription = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Rating
    {
        get { return _rating; }
        set { _rating = value; }
    }

    public string ProductImage
    {
        get { return _productImage; }
        set { _productImage = value; }
    }

    public string ProductCategory
    {
        get { return _productCategory; }
        set { _productCategory = value; }
    }

    public Product GetProduct(string id)
    {
        Product productDetail = null;

        string productName, productDescription, productImage, productCategory;
        decimal price;
        int rating;

        string queryStr = "SELECT * FROM All_Products WHERE ID = @ID";

        using (SqlConnection conn = new SqlConnection(_connStr))
        {
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    productName = dr["ProductName"].ToString();
                    productDescription = dr["ProductDescription"].ToString();
                    productImage = dr["ProductImage"].ToString();
                    price = decimal.Parse(dr["Price"].ToString());
                    rating = int.Parse(dr["Rating"].ToString());
                    productCategory = dr["ProductCategory"].ToString();

                    productDetail = new Product(id, productName, productDescription, price, rating, productImage, productCategory);
                }

                dr.Close();
            }
        }

        return productDetail;
    }
}
