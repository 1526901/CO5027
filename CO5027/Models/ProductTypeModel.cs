using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Models
{
    public class ProductTypeModel
    {
        public string InsertProductType(ProductType productType)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();
                db.ProductTypes.Add(productType);
                db.SaveChanges();

                return productType.Name + " was successfully inserted.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        public string UpdateProductType(int id, ProductType productType)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();

                ProductType p = db.ProductTypes.Find(id);

                p.Name = productType.Name;

                return productType.Name + " was successfully updated.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        public string DeleteProductType(int id)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();
                ProductType productType = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productType);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType.Name + " was successfully deleted.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}