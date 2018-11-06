namespace NServiceBusPoC.BussinesLogic.Entities.UserDomain
{
    public class EmailConfirmationDto
    {
        public string Email { get; set; }

        public int RoleId { get; set; }

        public string Guid { get; set; }
    }
}
