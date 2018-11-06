using System;

namespace NServiceBusPoC.Core.Persistance.Entities
{
    public class User
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string SecondName { get; set; }

        public string SecondSurname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }

        public string Nationality { get; set; }

        public string DNI { get; set; }

        public string SocialNumber { get; set; }

    }
}
