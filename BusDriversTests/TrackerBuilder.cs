using System.Collections.Generic;
using BusDrivers;

namespace BusDriversTests
{
    public class TrackerBuilder
    {
        private readonly List<BusDriver> _drivers;

        public TrackerBuilder()
        {
            _drivers = new List<BusDriver>();
        }
        public TrackerBuilder WithDriver(BusDriver driver)
        {
            _drivers.Add(driver);
            return this;
        }

        public Tracker Build()
        {
            return new Tracker(_drivers);
        }
    }
}