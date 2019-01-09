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

            driver1.ExchangeGossip(driver2);
            driver2.ExchangeGossip(driver1);

            Assert.Contains(gossip1, driver1.Gossips);
            Assert.Contains(gossip2, driver1.Gossips);

            Assert.Contains(gossip1, driver2.Gossips);
            Assert.Contains(gossip2, driver2.Gossips);
        }
    }
}
