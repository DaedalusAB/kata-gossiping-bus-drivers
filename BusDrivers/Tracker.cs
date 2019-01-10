using System;
using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public class Tracker
    {
        private const int MaxMinutesToGossip = 480;

        private readonly List<BusDriver> _drivers;
        private readonly int _gossipCount;

        public Tracker(List<BusDriver> drivers)
        {
            _drivers = drivers ?? throw new ArgumentNullException(nameof(drivers));
            _gossipCount = _drivers
                .SelectMany(d => d.Gossips)
                .Distinct()
                .Count();
        }

        public int Track()
        {
            var minutesPassed = 0;

            do
            {
                _drivers.ExchangeGossips();
                _drivers.MoveToNextStop();
                minutesPassed++;

            } while (!AllDriversHaveAllGossips() && minutesPassed <= MaxMinutesToGossip);

            return minutesPassed > MaxMinutesToGossip
                ? -1
                : minutesPassed;
        }

        private bool AllDriversHaveAllGossips() =>
            _drivers.All(d => d.GossipCount == _gossipCount);
    }
}