using System.Collections.Generic;

namespace BusDrivers
{
    public class Route : ValueObject
    {
        private readonly int[] _stops;

        public int Length =>
            _stops.Length;

        public Route(int[] stops)
        {
            _stops = stops;
        }

        public int GetStop(int stopIndex) =>
            _stops[stopIndex];

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _stops;
        }
    }
}