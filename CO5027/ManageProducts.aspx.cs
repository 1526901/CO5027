using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CO5027.Management
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetImages();

            if(!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }

        private void FillPage(int id)
        {
            Models.ProductModel productmodel = new Models.ProductModel();
            Product product = productmodel.GetProduct(id);

            txtDescription.Text = product.Description;
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();

            ddlImage.SelectedValue = product.Image;
            ddlType.SelectedValue = product.TypeID.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Models.ProductModel productModel = new Models.ProductModel();
            Product product = CreateProduct();

            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = productModel.UpdateProduct(id, product);
            }
            else
            {
                lblResult.Text = productModel.InsertProduct(product);
            }
        }

        private void GetImages()
        {
            try
            {
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

                ArrayList imageList = new ArrayList();
                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }

                ddlImage.DataSource = imageList;
                ddlImage.AppendDataBoundItems = true;
                ddlImage.DataBind();
            }
            catch (Exception e)
            {
                lblResult.Text = e.ToString();
            }
        }

        private Product CreateProduct()
        {
            Product product = new Product();

            product.Name = txtName.Text;
            product.Price = Convert.ToInt32(txtPrice.Text);
            product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
            product.Description = txtDescription.Text;
            product.Image = ddlImage.SelectedValue;

            return product;
        }
    }
}