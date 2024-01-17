using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApp2
{
    public partial class ChartControl1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetChartData();
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
                this.MasterPageFile = "~/AdminMaster.Master";
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