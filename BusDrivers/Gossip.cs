using System.Collections.Generic;

namespace BusDrivers
{
    public class Gossip : ValueObject
    {
        public string Text { get; }

        public Gossip(string text)
        {
            Text = text;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Text;
        }
    }
}