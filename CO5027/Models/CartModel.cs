using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Models
{
    public class CartModel
    {
        public string InsertCart(Cart cart)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();
                db.Carts.Add(cart);
                db.SaveChanges();

                return cart.DatePurchased + ": successfully added.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        public string UpdateCart(int id, Cart cart)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();

                Cart p = db.Carts.Find(id);

                p.DatePurchased = cart.DatePurchased;
                p.ClientID = cart.ClientID;
                p.Amount = cart.Amount;
                p.IsInCart = cart.IsInCart;
                p.ProductID = cart.ProductID;

                return cart.DatePurchased + ": successfully updated.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }

        public string DeleteCart(int id)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();
                Cart cart = db.Carts.Find(id);

                db.Carts.Attach(cart);
                db.Carts.Remove(cart);
                db.SaveChanges();

                return cart.DatePurchased + ": successfully deleted.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}