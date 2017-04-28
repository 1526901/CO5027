using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CO5027.Models;

namespace CO5027
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user is logged in
            string userId = User.Identity.GetUserId();

            //Display all items in user's cart.
            GetPurchasesInCart(userId);
        }

        protected void Delete_Item(object sender, EventArgs e)
        {
            ImageButton selectedLink = (ImageButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            int cartId = Convert.ToInt32(link);

            var cartModel = new CartModel();
            cartModel.DeleteCart(cartId);

            Response.Redirect("~/ShoppingCart.aspx");
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList selectedList = (DropDownList)sender;
            int cartId = Convert.ToInt32(selectedList.ID);
            int quantity = Convert.ToInt32(selectedList.SelectedValue);

            CartModel cartModel = new CartModel();
            cartModel.UpdateQuantity(cartId, quantity);
            Response.Redirect("~/ShoppingCart.aspx");
        }

        private void GetPurchasesInCart(string userId)
        {
            CartModel cartModel = new CartModel();
            double subTotal = 0;

            List<Cart> purchaseList = cartModel.GetOrdersInCart(userId);
            CreateShopTable(purchaseList, out subTotal);

            double totalAmount = subTotal + 5;

            litTotal.Text = "B$" + subTotal;
            litGrandTotal.Text = "B$" + totalAmount;

        }

        private void CreateShopTable(IEnumerable<Cart> carts, out double subTotal)
        {
            subTotal = new double();
            ProductModel model = new ProductModel();

            foreach (Cart cart in carts)
            {
                //Create HTML elements and fill values with database data
                Product product = model.GetProduct(cart.ProductID);

                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/Images/Products/{0}", product.Image),
                    PostBackUrl = string.Format("~/Product.aspx?id={0}", product.ID),
                    AlternateText = "Product",
                    Height = 150,
                    Width = 150
                };

                ImageButton lnkDelete = new ImageButton
                {
                    PostBackUrl = string.Format("~/ShoppingCart.aspx?ProductId={0}", cart.ID),
                    ImageUrl = string.Format("~/Images/delete.png"),
                    AlternateText = "Delete",
                    Height = 30,
                    Width = 30,
                    ImageAlign = ImageAlign.Middle,
                    ID = "del" + cart.ID,
                };

                lnkDelete.Click += Delete_Item;

                int[] amount = Enumerable.Range(1, 10).ToArray();
                DropDownList ddlAmount = new DropDownList
                {
                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = cart.ID.ToString()
                };
                ddlAmount.DataBind();
                ddlAmount.SelectedValue = cart.Amount.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                //Create table to hold shopping cart details
                Table table = new Table { CssClass = "CartTable" };
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();

                TableCell a1 = new TableCell { RowSpan = 2, Width = 180 };
                TableCell a2 = new TableCell {
                    Text = string.Format("<h4>{0}</h4>",
                product.Name),
                    HorizontalAlign = HorizontalAlign.Left,
                    VerticalAlign = VerticalAlign.Top,
                    Width = 350,
                    Height = 10
                };
                TableCell a3 = new TableCell { Text = "<h4>Price</h4>",
                    VerticalAlign = VerticalAlign.Top,
                    Width = 100, Height = 10
                };
                TableCell a4 = new TableCell { Text = "<h4>Quantity</h4>",
                    VerticalAlign = VerticalAlign.Top,
                    Width = 100, Height = 10
                };
                TableCell a5 = new TableCell { Text = "<h4>Subtotal</h4>",
                    VerticalAlign = VerticalAlign.Top,
                    Width = 100,
                    Height = 10
                };
                TableCell a6 = new TableCell();

                TableCell b1 = new TableCell { Text = string.Format("{0}<br/><br/>Available", "Product Number:" + product.ID), HorizontalAlign = HorizontalAlign.Left };
                TableCell b2 = new TableCell { Text = "B$" + product.Price};
                TableCell b3 = new TableCell();
                TableCell b4 = new TableCell { Text = "B$" + Math.Round((cart.Amount * (double)product.Price), 2) };
                TableCell b5 = new TableCell();
                TableCell b6 = new TableCell();



                //Set custom controls
                a1.Controls.Add(btnImage);
                b3.Controls.Add(ddlAmount);
                b5.Controls.Add(lnkDelete);

                //Add rows & cells to table
                row1.Cells.Add(a1);
                row1.Cells.Add(a2);
                row1.Cells.Add(a3);
                row1.Cells.Add(a4);
                row1.Cells.Add(a5);
                row1.Cells.Add(a6);

                row2.Cells.Add(b1);
                row2.Cells.Add(b2);
                row2.Cells.Add(b3);
                row2.Cells.Add(b4);
                row2.Cells.Add(b5);
                table.Rows.Add(row1);
                table.Rows.Add(row2);
                pnlShoppingCart.Controls.Add(table);

                //Add total of current purchased item to subtotal
                subTotal += (cart.Amount * product.Price);
            }

            //Add selected objects to Session
            Session[User.Identity.GetUserId()] = carts;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}