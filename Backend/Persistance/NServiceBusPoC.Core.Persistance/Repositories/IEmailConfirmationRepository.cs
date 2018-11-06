using NServiceBusPoC.Core.Persistance.Entities;
using System;

namespace NServiceBusPoC.Core.Persistance.Repositories
{
    public interface IEmailConfirmationRepository : IGenericRepository<EmailConfirmation>
    {
        void AddEmailConfirmation(string Email, int RoleId, Guid guidGenerated, TimeSpan timeToAddToExpire);

        Guid GetValidCode(string Email);

        void ConsumeEmail(EmailConfirmation emailobtained);
    }
}
