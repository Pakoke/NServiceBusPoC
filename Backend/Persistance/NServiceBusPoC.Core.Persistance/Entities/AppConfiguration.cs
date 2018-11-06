using NServiceBusPoC.Core.Entities;
using System;

namespace NServiceBusPoC.Core.Persistance.Entities
{
    public class AppConfiguration
    {
        public int ConfigurationId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public object ValueFormated
        {
            get
            {
                switch (ConfigurationId)
                {
                    case (int)AppConfigurationEnum.EmailAddress:
                    case (int)AppConfigurationEnum.EmailConfirmationBodyLocation:
                    case (int)AppConfigurationEnum.EmailConfirmationSubject:
                    case (int)AppConfigurationEnum.SMTPHostName:
                    case (int)AppConfigurationEnum.SMTPPassword:
                    case (int)AppConfigurationEnum.SMTPUser:
                        return Value;
                    case (int)AppConfigurationEnum.MinutesValidRegisterLink:
                        return TimeSpan.FromMinutes(double.Parse(Value.ToString()));
                    default:
                        return Value;
                }
            }
        }
    }
}
