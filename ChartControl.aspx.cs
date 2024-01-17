using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApp2
{
    public partial class ChartControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetChartData();
            }
        }

        private void GetChartData()
        {
            string cs = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductCategory, COUNT(*) AS CategoryCount FROM All_Products GROUP BY ProductCategory", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Series series = Chart1.Series["ProductCategories"];
                series.Points.Clear();

                while (rdr.Read())
                {
                    string categoryName = rdr["ProductCategory"].ToString();
                    int categoryCount = Convert.ToInt32(rdr["CategoryCount"]);
                    series.Points.AddXY(categoryName, categoryCount);
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChartType = DropDownList1.SelectedValue;
            Series series = Chart1.Series["ProductCategories"];

            if (series != null)
            {
                series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), selectedChartType);
            }

            // Refresh the chart to apply the changes
            GetChartData();
        }
    }


}






