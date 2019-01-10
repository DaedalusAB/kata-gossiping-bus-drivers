using System.Collections.Generic;

namespace BusDrivers
{
    public class Route : ValueObject
    {
        private readonly int[] _stops;

        public int this[int i] => 
            _stops[i];

        public int Length =>
            _stops.Length;

        public Route(int[] stops)
        {
            _stops = stops;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _stops;    //  TODO
        }
    }
}