using AutoFixture;
using NServiceBusPoC.BussinesLogic;
using NServiceBusPoC.BussinesLogic.Entities.UserDomain;
using NServiceBusPoC.BussinesLogic.UserDomain;
using NServiceBusPoC.Core.Entities;
using NServiceBusPoC.Core.Persistance;
using NServiceBusPoC.Core.Persistance.Entities;
using NServiceBusPoC.Core.Persistance.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace NServiceBusPoC.BussinesLogicTests
{
    [TestClass]
    public class UserBussinesLogicUnitTests
    {
        private IUserBussinesLogic _userBussinesLogic;
        private Mock<IUserRepository> _userRepository;
        private Mock<IEmailConfirmationRepository> _emailConfigurationRepository;
        private Mock<IAppConfigurationRepository> _appconfigurationRepository;
        private Mock<IGenericUoW> _mockUoW;


        public UserBussinesLogicUnitTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _emailConfigurationRepository = new Mock<IEmailConfirmationRepository>();
            _appconfigurationRepository = new Mock<IAppConfigurationRepository>();
            _mockUoW = new Mock<IGenericUoW>();

            List<AppConfiguration> mockConfigurations = new List<AppConfiguration>();
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.SMTPUser, Name = "SMTPUser", Value = "noreplymyNServiceBusPoC@gmail.com" });
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.SMTPPassword, Name = "SMTPPassword", Value = "Broadgate.Tower0NServiceBusPoC" });// 1and1 -> Broadgate.Tower0NServiceBusPoC
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.SMTPHostName, Name = "SMTPHostName", Value = "smtp.gmail.com" });
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.EmailAddress, Name = "EmailAddress", Value = "noreplymyNServiceBusPoC@gmail.com" });
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.EmailConfirmationBodyLocation, Name = "EmailConfirmationBodyLocation", Value = "F:/Windows/Trabajos/NServiceBusPoC/Backend/Persistance/NServiceBusPoC.Core.Database/EmailTemplateConfirmation.html" });
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.EmailConfirmationSubject, Name = "EmailConfirmationSubject", Value = "Confirmation Registration on NServiceBusPoC" });
            mockConfigurations.Add(new AppConfiguration() { ConfigurationId = (int)AppConfigurationEnum.MinutesValidRegisterLink, Name = "MinutesValidRegisterLink", Value = "120,0" });

            _appconfigurationRepository.Setup(e => e.GetAll(null))
                .Returns(mockConfigurations);

            foreach (var configuration in mockConfigurations)
            {
                _appconfigurationRepository.Setup(e => e.GetById(configuration.ConfigurationId))
                    .Returns(configuration);
            }



        }

        [TestMethod]
        public void When_AddParent_WithACorrectAge_And_SendEmail()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Build<UserDto>()
                .Without<DateTime>(p => p.BirthDate)
                .Without<RoleUserEnum>(p => p.Role)
                .Without<string>(p => p.Email)
                .Create();

            user.BirthDate = DateTime.UtcNow.AddYears(18);
            user.Role = RoleUserEnum.Parent;
            user.Email = "jrdlt1991@gmail.com";
            _userBussinesLogic = new UserBussinesLogic(_userRepository.Object, _mockUoW.Object, _emailConfigurationRepository.Object, _appconfigurationRepository.Object);

            Action act = () => _userBussinesLogic.CreateNewUserAndSendConfirmationEmail(user);

            act.Should().NotThrow<Exception>();
            _userRepository.Verify(p => p.Add(It.IsAny<User>()), Times.Once);
            _appconfigurationRepository.Verify(p => p.GetById(It.IsAny<int>()), Times.Once);
            _emailConfigurationRepository.
                Verify(e => e.AddEmailConfirmation(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<TimeSpan>()), Times.Once);

        }



    }
}
