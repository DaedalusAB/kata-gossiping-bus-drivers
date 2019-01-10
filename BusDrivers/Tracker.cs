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
            var movesMade = 0;

            do
            {
                ExchangeAll();
                MoveAll();
                movesMade++;

            } while (!AllDriversHaveAllGossips() && movesMade <= MaxMoves);

            return movesMade > MaxMoves
                ? -1
                : movesMade;
        }

        private bool AllDriversHaveAllGossips() =>
            _drivers.All(d => d.GossipCount == _drivers.Count);

        private void ExchangeAll() =>
            _drivers.ForEach(d => d.ReceiveGossips(DriversAt(d.CurrentStop)));

        private IEnumerable<BusDriver> DriversAt(int stopIndex) => 
            _drivers.Where(d => d.CurrentStop == stopIndex);

        private void MoveAll() =>
            _drivers.ForEach(d => d.MoveToNextStop());
    }
}