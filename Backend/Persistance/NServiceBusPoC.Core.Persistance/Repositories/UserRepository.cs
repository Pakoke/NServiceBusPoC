using NServiceBusPoC.Core.Persistance.Context;
using NServiceBusPoC.Core.Persistance.Entities;

namespace NServiceBusPoC.Core.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NServiceBusPoCContext dbContext) : base(dbContext)
        {
        }
    }
}
