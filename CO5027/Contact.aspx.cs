using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace CO5027
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mails = new MailMessage("1526901chester@gmail.com", "1526901chester@gmail.com");

                SmtpClient Client = new SmtpClient();
                Client.Host = "smtp.gmail.com";
                Client.Port = 587;
                System.Net.NetworkCredential Credentials = new NetworkCredential("1526901chester@gmail.com", "Che19940607");
                Client.Credentials = Credentials;
                Client.EnableSsl = true;

                mails.Subject = txtSubject.Text;
                mails.Body = "Name: " + txtName.Text + "\n";
                mails.Body += "Email: " + txtEmail.Text + "\n";
                mails.Body += "Subject: " + txtSubject.Text + "\n";
                mails.Body += "Message: " + txtMessage.Text;

                Client.Send(mails);

                txtName.Text = "";
                txtEmail.Text = "";
                txtSubject.Text = "";
                txtMessage.Text = "";

                Literal1.Text = "Message sent.";

            }
            catch(Exception exc)
            {
                Literal1.Text = "Send Failed." + exc.Message + exc.InnerException;
            }
        }
    }
}