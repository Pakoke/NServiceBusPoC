using System.ComponentModel.DataAnnotations;

namespace NServiceBusPoC.UI.ViewEntities
{
    public class UserLoginRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
