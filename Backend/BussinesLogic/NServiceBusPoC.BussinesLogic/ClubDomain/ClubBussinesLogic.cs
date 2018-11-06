using NServiceBusPoC.BussinesLogic.CommonDomain;
using NServiceBusPoC.BussinesLogic.Entities.ClubDomain;
using NServiceBusPoC.Core.Persistance;
using NServiceBusPoC.Core.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;
namespace NServiceBusPoC.BussinesLogic.ClubDomain
{
    public class ClubBussinesLogic : IClubBussinesLogic, IBussinesLogic
    {

        private readonly IClubRepository _clubRepository;
        private readonly IGenericUoW _genericUoW;

        public ClubBussinesLogic(IClubRepository userRepository, IGenericUoW genericUoW)
        {
            _clubRepository = userRepository;
            _genericUoW = genericUoW;
        }

        public IEnumerable<ClubDto> GetAllClubs()
        {
            List<ClubDto> clubs = new List<ClubDto>();
            var allClubsFromdb = _clubRepository.GetAll().ToList();

            allClubsFromdb.ForEach(c =>
            clubs.Add(new ClubDto()
            {
                ClubId = c.ClubId,
                ClubName = c.ClubName,
                Contact = c.Contact,
                LimitDateChild = c.LimitDateChild,
                Location = c.Location,
                NumberOfCoach = c.NumberOfCoach
            }));

            return clubs;
        }

        public ClubDto GetClub(int id)
        {
            var clubFromdb = _clubRepository.GetById(id);
            return new ClubDto()
            {
                ClubId = clubFromdb.ClubId,
                ClubName = clubFromdb.ClubName,
                Contact = clubFromdb.Contact,
                LimitDateChild = clubFromdb.LimitDateChild,
                Location = clubFromdb.Location,
                NumberOfCoach = clubFromdb.NumberOfCoach
            };
        }
    }
}
