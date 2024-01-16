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
    public partial class Afterlogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("Search.aspx");
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
    }
}

