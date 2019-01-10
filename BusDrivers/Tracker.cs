using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public class Tracker
    {
        private readonly List<BusDriver> _drivers;
        private const int MaxMinutesToGossip = 480;
        private readonly int _gossipCount;
            

        public Tracker(List<BusDriver> drivers)
        {
            _drivers = drivers;
            _gossipCount = _drivers.SelectMany(d => d.Gossips).ToList().Distinct().Count();
        }

        public int Track()
        {
            var minutesPassed = 0;

            do
            {
                ExchangeAll();
                MoveAll();
                minutesPassed++;

            } while (!AllDriversHaveAllGossips() && minutesPassed <= MaxMinutesToGossip);

            return minutesPassed > MaxMinutesToGossip
                ? -1
                : minutesPassed;
        }

        private bool AllDriversHaveAllGossips() =>
            _drivers.All(d => d.GossipCount == _gossipCount);

        private void ExchangeAll() =>
            _drivers.ForEach(d => d.ReceiveGossips(DriversAt(d.CurrentStop)));

        private IEnumerable<BusDriver> DriversAt(int stopIndex) => 
            _drivers.Where(d => d.CurrentStop == stopIndex);

        private void MoveAll() =>
            _drivers.ForEach(d => d.MoveToNextStop());
    }
}