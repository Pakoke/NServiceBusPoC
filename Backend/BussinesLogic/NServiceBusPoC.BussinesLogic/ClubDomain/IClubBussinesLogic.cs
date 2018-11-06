using NServiceBusPoC.BussinesLogic.Entities.ClubDomain;
using System.Collections.Generic;

namespace NServiceBusPoC.BussinesLogic.ClubDomain
{
    public interface IClubBussinesLogic
    {
        ClubDto GetClub(int id);

        IEnumerable<ClubDto> GetAllClubs();
    }
}
