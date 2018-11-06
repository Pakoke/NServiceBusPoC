using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;

namespace NServiceBusPoC.Core.Utils.SmtpMethods
{
    public class NServiceBusPoCSmtpClient : INServiceBusPoCSmtpClient
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string MailAddress { get; set; }

        public string SMTPHostName { get; set; }

        public string BodyLocationDir { get; set; }

        public string Subject { get; set; }

        public void SendWelcomeEmail(string GuidUrl, string EmailDestination)
        {
            //get the credential using the configuration database and call the SMTP server

            SmtpClient client = new SmtpClient(SMTPHostName);
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Username, Password);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(MailAddress);
            mailMessage.To.Add(EmailDestination);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = FormatWelcomeEmailHtml(BodyLocationDir, GuidUrl, EmailDestination);
            mailMessage.Subject = Subject;
            client.Send(mailMessage);

        }

        private string FormatWelcomeEmailHtml(string FileLocation, string GuidUrl, string EmailDestination)
        {
            string bodyWithoutReplacement = string.Empty;
            StringBuilder builder = new StringBuilder(string.Empty);

            XmlDocument doc = new XmlDocument();
            doc.Load(FileLocation);

            var welcomeFormated = string.Format(doc.GetElementsByTagName("p")[0].InnerText, EmailDestination);
            doc.GetElementsByTagName("p")[0].InnerText = welcomeFormated;

            string urlFormated = string.Format(doc.GetElementsByTagName("a")[0].Attributes[2].InnerText, GuidUrl);
            doc.GetElementsByTagName("a")[0].Attributes[2].InnerText = urlFormated;

            return doc.InnerXml;

        }
    }
}
