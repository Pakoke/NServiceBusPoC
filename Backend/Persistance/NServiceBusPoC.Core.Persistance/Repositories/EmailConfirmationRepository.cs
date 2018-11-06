using NServiceBusPoC.Core.Persistance.Context;
using NServiceBusPoC.Core.Persistance.Entities;
using System;

namespace NServiceBusPoC.Core.Persistance.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(NServiceBusPoCContext dbContext) : base(dbContext)
        {
        }

        public void AddEmailConfirmation(string Email, int RoleId, Guid guidGenerated, TimeSpan timeToAddToExpire)
        {

            this.Add(new EmailConfirmation()
            {
                Consumed = false,
                CreatedDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.Add(timeToAddToExpire),
                RoleId = RoleId,
                Email = Email,
                GuidUrl = guidGenerated.ToString()
            });
        }

        public void ConsumeEmail(EmailConfirmation emailobtained)
        {
            emailobtained.Consumed = true;
            this.Edit(emailobtained);
        }

        public Guid GetValidCode(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
