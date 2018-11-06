using Microsoft.Extensions.FileProviders;
using NServiceBusPoC.BussinesLogic.Entities.UserDomain;
using NServiceBusPoC.Core.Entities;
using NServiceBusPoC.Core.Persistance;
using NServiceBusPoC.Core.Persistance.Entities;
using NServiceBusPoC.Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NServiceBusPoC.BussinesLogic.UserDomain
{
    public class UserBussinesLogic : IUserBussinesLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenericUoW _genericUoW;
        private readonly IEmailConfirmationRepository _emailConfirmationRepository;
        private readonly IAppConfigurationRepository _appConfigurationRepository;
        private readonly IFileProvider _fileProvider;

        public UserBussinesLogic(IUserRepository userRepository,
            IGenericUoW genericUoW,
            IEmailConfirmationRepository emailConfirmationRepository,
            IAppConfigurationRepository appConfigurationRepository)
        {
            _userRepository = userRepository;
            _genericUoW = genericUoW;
            _emailConfirmationRepository = emailConfirmationRepository;
            _appConfigurationRepository = appConfigurationRepository;

            _fileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);

        }

        public bool CreateNewUserAndSendConfirmationEmail(UserDto user)
        {
            User userdb = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                SecondName = user.SecondName,
                SecondSurname = user.SecondSurname,
                Email = user.Email,
                Password = user.Password,
                RoleId = (int)user.Role,
                Enabled = false,
                BirthDate = user.BirthDate,
                Country = user.Country,
                DNI = user.DNI,
                Nationality = user.Nationality,
                SocialNumber = user.SocialNumber,
                Street = user.Street
            };

            if (userdb.RoleId == (int)RoleUserEnum.Parent)
            {
                //Has more than 18 years ago.
                if (userdb.BirthDate.Date < DateTime.Now.Date.AddYears(-18))
                {
                    throw new Exception("The person doesn´t have enough age to be a parent or a coach");
                }
            }

            try
            {
                _userRepository.Add(userdb);

                Guid guidGenerate = Guid.NewGuid();

                var configuration = _appConfigurationRepository.GetById((int)AppConfigurationEnum.MinutesValidRegisterLink);

                _emailConfirmationRepository.AddEmailConfirmation(userdb.Email, userdb.RoleId, guidGenerate, (TimeSpan)configuration.ValueFormated);

                _genericUoW.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Problem creating a new user", e.InnerException);
            }

        }

        public bool ValidUser(UserDto user)
        {
            User userdb = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                SecondName = user.SecondName,
                SecondSurname = user.SecondSurname,
                Email = user.Email,
                Password = user.Password,
                RoleId = (int)user.Role,
                Enabled = false,
                Country = user.Country,
                DNI = user.DNI,
                Nationality = user.Nationality,
                SocialNumber = user.SocialNumber,
                Street = user.Street
            };

            bool userValid = true;

            //Check if the user already exist
            var resultObtained = GetExistingUser(userdb);
            if (resultObtained == null)
            {
                //Check if according to the Club,the child can enter and check the birthdate

                if (userdb.RoleId == (int)RoleUserEnum.Parent)
                {

                }
                else if (userdb.RoleId == (int)RoleUserEnum.Child)
                {

                }
                //Check if according to the Club, the user can be fullfil the number of Coach

                //Check the age of the coach

                //Check the location of the Coach

            }
            else
            {
                userValid = false;
            }

            return userValid;
        }

        private User GetExistingUser(User user)
        {
            return _userRepository.GetById(user.Email, user.RoleId);
        }

        public EmailConfirmationDto GetEmailConfirmationById(string id)
        {

            //Obtain all the email that match with the exact Guid and the Expiration Date doesn´t pass yet.
            IEnumerable<EmailConfirmation> emailConfirmation = _emailConfirmationRepository.GetAll(x => x.GuidUrl == id && x.ExpirationDate >= DateTime.UtcNow && x.Consumed == false);
            if (emailConfirmation.Count() > 1)
            {
                return null;
            }
            else
            {
                if (emailConfirmation.Count() == 0)
                {
                    return null;
                }
                else
                {
                    var emailFound = emailConfirmation.First();

                    return new EmailConfirmationDto() { Email = emailFound.Email, RoleId = emailFound.RoleId, Guid = emailFound.GuidUrl };
                }
            }

        }

        public UserDto GetExistingFullInfoByUserId(UserDto user)
        {

            var userObtained = _userRepository.GetById(user.Email, (int)user.Role);

            return new UserDto()
            {
                BirthDate = userObtained.BirthDate,
                //TODO obtain the club
                //Club = userObtained.,
                Country = userObtained.Country,
                DNI = userObtained.DNI,
                Email = userObtained.Email,
                Name = userObtained.Name,
                Surname = userObtained.Surname,
                SecondName = userObtained.SecondName,
                SecondSurname = userObtained.SecondSurname,
                Street = userObtained.Street,
                SocialNumber = userObtained.SocialNumber,
                Role = user.Role,
                Nationality = userObtained.Nationality,
            };


        }

        public void ConsumeEmailConfirmation(string email, int roleId, string id)
        {
            try
            {
                var emailobtained = _emailConfirmationRepository.GetById(email, roleId, id);

                _emailConfirmationRepository.ConsumeEmail(emailobtained);

                _genericUoW.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Problem trying to consume the email given", e.InnerException);
            }
        }

        public UserDto GetUserByPassword(UserDto user)
        {
            var userFromDB = _userRepository.GetAll(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (userFromDB != null)
            {
                return new UserDto()
                {
                    BirthDate = userFromDB.BirthDate,
                    //TODO obtain the club
                    //Club = userObtained.,
                    Country = userFromDB.Country,
                    DNI = userFromDB.DNI,
                    Email = userFromDB.Email,
                    Name = userFromDB.Name,
                    Surname = userFromDB.Surname,
                    SecondName = userFromDB.SecondName,
                    SecondSurname = userFromDB.SecondSurname,
                    Street = userFromDB.Street,
                    SocialNumber = userFromDB.SocialNumber,
                    Role = (RoleUserEnum)userFromDB.RoleId,
                    Nationality = userFromDB.Nationality,
                };
            }
            else
            {
                return null;
            }

        }
    }
}
