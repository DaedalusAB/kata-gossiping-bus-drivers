using System.Collections.Generic;
using System.Linq;

namespace BusDrivers
{
    public static class BusDriverExtensions
    {
        public static void ExchangeGossips(this IEnumerable<BusDriver> drivers)
        {
            var driversList = drivers.ToList();
            driversList.ForEach(d => d.ReceiveGossips(driversList.At(d.CurrentStop)));
        }

        public static void MoveToNextStop(this IEnumerable<BusDriver> drivers) =>
            drivers.ToList().ForEach(d => d.MoveToNextStop());

        private static IEnumerable<BusDriver> At(this IEnumerable<BusDriver> drivers, int stopIndex) =>
            drivers.Where(d => d.CurrentStop == stopIndex).ToList();
    }
}
