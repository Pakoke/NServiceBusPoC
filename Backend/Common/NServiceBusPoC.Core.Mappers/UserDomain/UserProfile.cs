using AutoMapper;
using NServiceBusPoC.BussinesLogic.Entities.UserDomain;
using NServiceBusPoC.UI.ViewEntities;
namespace NServiceBusPoC.Core.Mappers.UserDomain
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterRequest, UserDto>();
            CreateMap<UserDto, UserRegisterRequest>();
        }
    }
}
