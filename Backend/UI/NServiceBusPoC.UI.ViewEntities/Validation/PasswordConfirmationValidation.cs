using System.ComponentModel.DataAnnotations;

namespace NServiceBusPoC.UI.ViewEntities.Validation
{
    public class PasswordConfirmationValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            UserRegisterRequest userRegister = (UserRegisterRequest)validationContext.ObjectInstance;

            if (userRegister.Password.Equals(userRegister.ConfirmationPassword))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The password has to be the same in both fields");

        }
    }
}
