using System.Net;
using System.Net.Mail;

namespace SeleniumHarness
{
    public static class Mail
    {

        public static void send(string _body, string toEmail)
        {

            var fromAddress = new MailAddress("errors@hackandcraft.com", "Selenium");
            var toAddress = new MailAddress(toEmail, "H&C");
            const string fromPassword = "Popov2010";
            const string subject = "Selenium Log";
            string body = _body;

            var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
            using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
            {
                smtp.Send(message);
            }
        }

    }
}
