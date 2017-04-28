using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace CO5027
{
    public partial class Product1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Models.ProductModel productModel = new Models.ProductModel();
                Product product = productModel.GetProduct(id);

                lblPrice.Text = "B$" + product.Price;
                lblTitle.Text = product.Name;
                lblDescription.Text = product.Description;
                lblItemNo.Text = id.ToString();
                imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
                imgProduct.AlternateText = "Product";

                int[] amount = Enumerable.Range(1, 10).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string clientId = Context.User.Identity.GetUserId();

                if (clientId != null)
                {

                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                    Cart cart = new Cart
                    {
                        Amount = amount,
                        ClientID = clientId,
                        DatePurchased = DateTime.Now,
                        IsInCart = true,
                        ProductID = id
                    };

                    Models.CartModel model = new Models.CartModel();
                    lblResult.Text = model.InsertCart(cart);
                }
                else
                {
                    lblResult.Text = "Please log in to order items.";
                }
            }
        }
    }
}