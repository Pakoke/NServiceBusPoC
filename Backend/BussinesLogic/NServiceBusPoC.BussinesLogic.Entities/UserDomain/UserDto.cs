using NServiceBusPoC.Core.Entities;
using System;

namespace NServiceBusPoC.BussinesLogic.Entities.UserDomain
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string SecondName { get; set; }

        public string SecondSurname { get; set; }

        public ClubEnum Club { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmationPassword { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Coach,Parent,Child
        /// </summary>
        public RoleUserEnum Role { get; set; }

        public string Country { get; set; }

        public string DNI { get; set; }

        public string Nationality { get; set; }

        public string SocialNumber { get; set; }

        public string Street { get; set; }
    }
}
