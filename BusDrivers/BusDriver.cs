using System.Collections.Generic;

namespace BusDrivers
{
    public class BusDriver
    {
        private readonly Route _route;
        private int _currentStopIndex;
        private readonly HashSet<Gossip> _gossips;

        public int CurrentStop =>
            _route[_currentStopIndex];
        
        public int GossipCount =>
            _gossips.Count;

        public IEnumerable<Gossip> Gossips =>
            _gossips;

        public BusDriver(Route route, Gossip gossip)
        {
            _route = route;
            _currentStopIndex = 0;
            _gossips = new HashSet<Gossip>() { gossip };

        }

        public void ReceiveGossips(IEnumerable<BusDriver> otherDrivers)
        {
            foreach (var otherDriver in otherDrivers)
            {
                ReceiveGossips(otherDriver);
            }
        }

        private void ReceiveGossips(BusDriver otherDriver) =>
            _gossips.UnionWith(otherDriver._gossips);

        public void MoveToNextStop() =>
            _currentStopIndex = (_currentStopIndex + 1) % _route.Length;

        public bool HasGossip(Gossip gossip) =>
            _gossips.Contains(gossip);
    }
}