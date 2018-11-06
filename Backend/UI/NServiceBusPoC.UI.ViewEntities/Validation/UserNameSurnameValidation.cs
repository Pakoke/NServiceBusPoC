using System.ComponentModel.DataAnnotations;

namespace NServiceBusPoC.UI.ViewEntities.Validation
{
    public class UserNameSurnameValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            UserRegisterRequest userRegister = (UserRegisterRequest)validationContext.ObjectInstance;

            //Logic todo

            return ValidationResult.Success;
        }
    }
}
