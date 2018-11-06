using NServiceBusPoC.Core.Persistance.Context;
using NServiceBusPoC.Core.Persistance.Entities;

namespace NServiceBusPoC.Core.Persistance.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(NServiceBusPoCContext dbContext) : base(dbContext)
        {
        }
    }
}
