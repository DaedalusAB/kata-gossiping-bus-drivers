using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public class Tracker
    {
        private readonly List<BusDriver> _drivers;
        private const int MaxMoves = 480;

        public Tracker(List<BusDriver> drivers)
        {
            _drivers = drivers;
        }

        public int Track()
        {
            ExchangeAll();
            var movesMade = 1;

            while (!AllDriversHaveAllGossips() && movesMade <= MaxMoves)
            {
                MoveAll();
                ExchangeAll();
                movesMade++;
            }

            return movesMade > MaxMoves
                ? -1
                : movesMade;
        }

        private bool AllDriversHaveAllGossips() =>
            _drivers.All(d => d.GossipCount == _drivers.Count);

        private void ExchangeAll() =>
            _drivers.ForEach(busDriver => busDriver.ReceiveGossips(_drivers.Where(d => d.CurrentStop == busDriver.CurrentStop)));

        private void MoveAll() =>
            _drivers.ForEach(d => d.MoveToNextStop());
    }
}