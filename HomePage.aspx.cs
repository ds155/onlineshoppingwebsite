using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    public partial class HomePage : System.Web.UI.Page
    {
        string conn_string = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 50;
        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {

            if (Session["@uid"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }

            // Get the product details from the DataList item
            DataListItem item = (DataListItem)((Button)sender).NamingContainer;
            Image Image1 = (Image)item.FindControl("Image1");
            Label Product_nameLabel = (Label)item.FindControl("Product_nameLabel");
            Label PriceLabel = (Label)item.FindControl("PriceLabel");
            Label DescriptionLabel = (Label)item.FindControl("DescriptionLabel");

            // Create a new product object and set its properties
            Product product = new Product();
            product.ProductName = Product_nameLabel.Text;
            product.Price = decimal.Parse(PriceLabel.Text);
            product.Description = DescriptionLabel.Text;
            product.Photo = System.IO.Path.Combine("~/Images/", Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1));

            // Add the product to the session
            List<Product> cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                cart = new List<Product>();
                Session["Cart"] = cart;
            }
            cart.Add(product);

            // Redirect to the Add to Cart page
            Response.Redirect("CartProduct.aspx");
        }

        protected void ButtonAddCart_Click(object sender, EventArgs e)
        {
            if (Session["@uid"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }

            // Get the product details from the DataList item
            DataListItem item = (DataListItem)((Button)sender).NamingContainer;
            Image Image1 = (Image)item.FindControl("Image1");
            Label Product_nameLabel = (Label)item.FindControl("Product_nameLabel");
            Label PriceLabel = (Label)item.FindControl("PriceLabel");
            Label DescriptionLabel = (Label)item.FindControl("DescriptionLabel");

            // Create a new product object and set its properties
            Product product = new Product();
            product.ProductName = Product_nameLabel.Text;
            product.Price = decimal.Parse(PriceLabel.Text);
            product.Description = DescriptionLabel.Text;
            product.Photo = System.IO.Path.Combine("~/Images/", Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1));

            // Add the product to the session
            List<Product> cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                cart = new List<Product>();
                Session["Cart"] = cart;
            }
            cart.Add(product);

            // Redirect to the Add to Cart page
            Response.Redirect("CartProduct.aspx");
        }


    }
}