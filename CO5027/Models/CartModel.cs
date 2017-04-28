using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CO5027.Models;

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

        public List<Cart> GetOrdersInCart(string userId)
        {
            CO5027Entities db = new CO5027Entities();
            List<Cart> orders = (from x in db.Carts where x.ClientID == userId && x.IsInCart orderby x.DatePurchased select x).ToList();

            return orders;
        }

        public int GetAmountOfOrders(string userId)
        {
            try
            {
                CO5027Entities db = new CO5027Entities();
                int amount = (from x in db.Carts where x.ClientID == userId && x.IsInCart select x.Amount).Sum();

                return amount;
            }
            catch
            {
                return 0;
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            CO5027Entities db = new CO5027Entities();
            Cart cart = db.Carts.Find(id);
            cart.Amount = quantity;

            db.SaveChanges();
        }

        public void MarkOrdersAsPaid(List<Cart> carts)
        {
            CO5027Entities db = new CO5027Entities();

            if(carts != null)
            {
                foreach(Cart cart in carts)
                {
                    Cart oldCart = db.Carts.Find(cart.ID);
                    oldCart.DatePurchased = DateTime.Now;
                    oldCart.IsInCart = false;
                }
                db.SaveChanges();
            }
        }
    }
}