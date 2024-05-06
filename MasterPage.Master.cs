using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["@uid"] != null)
            {
                ImageButton1.Visible = true;
                Label1.Visible = true;
                Label1.Text = Session["@uid"].ToString();
                LinkButton1.Visible = false;
                ButtonLogout.Visible = true;

            }
            else
            {
                Label1.Visible = false;
                ImageButton1.Visible = false;
                LinkButton1.Visible = true;
                ButtonLogout.Visible = false;
            }

            Session.Timeout = 50;
        }

        protected void ButtonLogout_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}