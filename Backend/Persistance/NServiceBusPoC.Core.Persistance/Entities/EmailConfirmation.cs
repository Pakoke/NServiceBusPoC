using System;

namespace NServiceBusPoC.Core.Persistance.Entities
{
    public class EmailConfirmation
    {
        public string Email { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string GuidUrl { get; set; }

        public bool Consumed { get; set; }

    }
}
