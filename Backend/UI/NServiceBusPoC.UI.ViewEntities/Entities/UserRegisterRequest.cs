using NServiceBusPoC.Core.Entities;
using NServiceBusPoC.UI.ViewEntities.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace NServiceBusPoC.UI.ViewEntities
{
    public class UserRegisterRequest
    {

        [UserNameSurnameValidation()]
        public string Name { get; set; }

        [UserNameSurnameValidation()]
        public string Surname { get; set; }

        [UserNameSurnameValidation()]
        public string SecondName { get; set; }

        [UserNameSurnameValidation()]
        public string SecondSurname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The club is required")]
        public ClubEnum Club { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [PasswordConfirmationValidation()]
        [DataType(DataType.Password)]
        public string ConfirmationPassword { get; set; }

        [DataType(DataType.Date, ErrorMessage = "The Date doesn´t have a good format")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Coach,Parent,Child
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The role is required")]
        public RoleUserEnum Role { get; set; }

        public string Country { get; set; }

        public string DNI { get; set; }

        public string Nationality { get; set; }

        public string SocialNumber { get; set; }

        public string Street { get; set; }


    }
}
