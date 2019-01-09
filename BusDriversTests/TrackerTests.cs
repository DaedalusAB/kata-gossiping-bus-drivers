using BusDrivers;
using Xunit;

namespace BusDriversTests
{
    public class TrackerTests
    {
        [Fact]
        public void Example1Test()
        {
            var driver1 = new DriverBuilder()
                .WithGossip(new Gossip("gossip 1"))
                .WithRoute(new[] {3, 1, 2, 3})
                .Build();

            var driver2 = new DriverBuilder()
                .WithGossip(new Gossip("gossip 2"))
                .WithRoute(new[] {3, 2, 3, 1})
                .Build();

            var driver3 = new DriverBuilder()
                .WithGossip(new Gossip("gossip 3"))
                .WithRoute(new[] {4, 2, 3, 4, 5})
                .Build();

            var tracker = new TrackerBuilder()
                .WithDriver(driver1)
                .WithDriver(driver2)
                .WithDriver(driver3)
                .Build();

            var result = tracker.Run();

            Assert.Equal(5, result);
        }

        [Fact]
        public void Example2Test()
        {
            var driver1 = new DriverBuilder()
                .WithGossip(new Gossip("gossip 1"))
                .WithRoute(new[] { 2, 1, 2 })
                .Build();

            var driver2 = new DriverBuilder()
                .WithGossip(new Gossip("gossip 2"))
                .WithRoute(new[] {5, 2, 8})
                .Build();

            var tracker = new TrackerBuilder()
                .WithDriver(driver1)
                .WithDriver(driver2)
                .Build();

            var result = tracker.Run();

            Assert.Equal(-1, result);
        }
    }
}
