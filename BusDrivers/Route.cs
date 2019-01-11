using System;
using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public class Route
    {
        private readonly int[] _stops;

        public int this[int i] =>
            _stops[i];

        public int Length =>
            _stops.Length;

        public Route(int[] stops)
        {
            _stops = stops ?? throw new ArgumentNullException(nameof(stops));
        }
    }
}