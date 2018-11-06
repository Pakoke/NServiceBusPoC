namespace NServiceBusPoC.Core.Utils.SmtpMethods
{
    public interface INServiceBusPoCSmtpClient
    {
        void SendWelcomeEmail(string GuidUrl, string EmailDestination);
    }
}
