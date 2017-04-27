using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CO5027
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            //Get a list of all products in DB
            Models.ProductModel productModel = new Models.ProductModel();
            List<Product> products = productModel.GetAllProduct();

            //Make sure products exist in the database
            if (products != null)
            {
                //Create a new Panel with an ImageButton and 2 abels for each Product
                foreach (Product product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton();
                    Label lblProductName = new Label();
                    Label lblPrice = new Label();

                    //Set childConrol's properties
                    imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                    imageButton.AlternateText = "Product";
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "~/Product.aspx?id=" + product.ID;

                    lblProductName.Text = product.Name;
                    lblProductName.CssClass = "productName";

                    lblPrice.Text = "$" + product.Price;
                    lblPrice.CssClass = "productPrice";

                    //Add child control to Panel
                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblProductName);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblPrice);

                    //Add dynamic Panels to static Parent panel
                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
            {
                //No products found
                pnlProducts.Controls.Add(new Literal { Text = "No products found!" });
            }
        }
    }
}