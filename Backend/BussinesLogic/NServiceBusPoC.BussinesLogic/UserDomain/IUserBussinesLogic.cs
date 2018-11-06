using NServiceBusPoC.BussinesLogic.Entities.UserDomain;

namespace NServiceBusPoC.BussinesLogic
{
    public interface IUserBussinesLogic
    {
        bool ValidUser(UserDto user);

        bool CreateNewUserAndSendConfirmationEmail(UserDto result);

        EmailConfirmationDto GetEmailConfirmationById(string id);

        UserDto GetExistingFullInfoByUserId(UserDto user);

        void ConsumeEmailConfirmation(string email, int roleId, string id);

        UserDto GetUserByPassword(UserDto user);
    }
}
