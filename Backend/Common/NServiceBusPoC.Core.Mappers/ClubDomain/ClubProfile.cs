using AutoMapper;
using NServiceBusPoC.BussinesLogic.Entities.ClubDomain;
using NServiceBusPoC.UI.ViewEntities.Entities;
using System.Collections.Generic;

namespace NServiceBusPoC.Core.Mappers.ClubDomain
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<ClubDto, ClubResponse>();
            CreateMap<IEnumerable<ClubDto>, IEnumerable<ClubResponse>>();
            CreateMap<List<ClubDto>, List<ClubResponse>>();

        }
    }
}
