using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public class BusDriver
    {
        private readonly Route _route;
        private int _currentStopIndex;

        public HashSet<Gossip> Gossips { get; }
        public int CurrentStop =>
            _route.GetStop(_currentStopIndex);


        public BusDriver(Route route, Gossip gossip)
        {
            _route = route;
            _currentStopIndex = 0;
            Gossips = new HashSet<Gossip>() { gossip };

        }

        public void ExchangeGossip(BusDriver otherDriver) => 
            Gossips.UnionWith(otherDriver.Gossips);

        public void ExchangeGossipWithAll(IEnumerable<BusDriver> otherDriveresAtStop)
        {
            foreach (var busDriver in otherDriveresAtStop)
            {
                ExchangeGossip(busDriver);
            }
        }

        public void MoveToNextStop() => 
            _currentStopIndex = (_currentStopIndex + 1 + _route.Length) % _route.Length;
    }
}