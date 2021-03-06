﻿using System;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CO5027
{
    public partial class CO5027 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            if (user.IsAuthenticated)
            {
                lnkLogin.Visible = false;
                lnkLogout.Visible = true;

                Models.CartModel model = new Models.CartModel();
                string userId = HttpContext.Current.User.Identity.GetUserId();
                Literal1.Text = string.Format("({0})", model.GetAmountOfOrders(userId));
                
            }
            else
            {
                lnkLogin.Visible = true;
                lnkLogout.Visible = false;
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            Response.Redirect("~/Default.aspx");
        }
    }
}