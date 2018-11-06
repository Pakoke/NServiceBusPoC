using NServiceBusPoC.Api.Controllers;
using NUnit.Framework;

namespace NServiceBusPoC.Api.Tests
{
    [TestFixture]
    public class StatusControllerTests
    {
        [Test]
        public void HealthcheckReturnsHealthyStatus()
        {
            var controller = new StatusController();
            var healthcheck = controller.get();

            Assert.That(healthcheck.Status == "healthy");
        }
    }
}
