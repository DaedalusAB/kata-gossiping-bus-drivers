using BusDrivers;
using Xunit;

namespace BusDriversTests
{
    public class BusDriverTests
    {
        [Fact]
        public void TwoDriversExchangeAllGossips()
        {
            var gossip1 = new Gossip("Gossip 1");
            var gossip2 = new Gossip("Gossip 2");

            var driver1 = new DriverBuilder()
                .WithRoute(new[] { 1, 2 })
                .WithGossip(gossip1)
                .Build();
            var driver2 = new DriverBuilder()
                .WithRoute(new[] { 1, 3 })
                .WithGossip(gossip2)
                .Build();

            driver1.ReceiveGossips(new[] { driver2 });
            driver2.ReceiveGossips(new[] { driver1 });

            Assert.True(driver1.HasGossip(gossip1));
            Assert.True(driver1.HasGossip(gossip2));

            Assert.True(driver2.HasGossip(gossip1));
            Assert.True(driver2.HasGossip(gossip2));

        }
    }
}
