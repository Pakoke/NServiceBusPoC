using NServiceBusPoC.Core.Persistance.Context;
using NServiceBusPoC.Core.Persistance.Entities;

namespace NServiceBusPoC.Core.Persistance.Repositories
{
    public class AppConfigurationRepository : GenericRepository<AppConfiguration>, IAppConfigurationRepository
    {
        public AppConfigurationRepository(NServiceBusPoCContext dbContext) : base(dbContext)
        {
        }
    }
}
