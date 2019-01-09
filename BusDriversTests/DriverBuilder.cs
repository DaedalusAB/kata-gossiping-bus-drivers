using BusDrivers;

namespace BusDriversTests
{
    public class DriverBuilder
    {
        private Route _route;
        private Gossip _gossip;

        public DriverBuilder WithRoute(int[] stops)
        {
            _route = new Route(stops);
            return this;
        }

        public DriverBuilder WithGossip(Gossip gossip)
        {
            _gossip = gossip;
            return this;
        }

        public BusDriver Build()
        {
            return new BusDriver(_route, _gossip);
        }
    }
}