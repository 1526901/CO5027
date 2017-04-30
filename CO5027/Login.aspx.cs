using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;


namespace CO5027
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CO5027ConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            IdentityUser user = new IdentityUser();
            user.UserName = txtUserName.Text;

            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                try
                {
                    IdentityResult result = manager.Create(user, txtPassword.Text);

                    if (result.Succeeded)
                    {

                        UserInformation info = new UserInformation
                        {
                            Address = txtAddress.Text,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Email = txtEmail.Text,
                            PostalCode = txtPostalCode.Text,
                            GUID = user.Id
                        };

                        UserInfoModel model = new UserInfoModel();
                        model.InsertUserInformation(info);

                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        litStatus.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    litStatus.Text = ex.ToString();
                }
            }
            else
            {
                litStatus.Text = "Passwords do not match.";
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CO5027ConnectionString"].ConnectionString;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["CO5027ConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtUsername1.Text, txtPassword1.Text);

            if (user != null)
            {
                //Call OWIN functionality
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in user
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect user to homepage
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                litStatus3.Text = "Invalid username or password.";
            }
        }
    }
}