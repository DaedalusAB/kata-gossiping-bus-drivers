using System;
using System.Collections.Generic;

namespace BusDrivers
{
    public class Gossip : ValueObject
    {
        private readonly string _text;

        public Gossip(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(nameof(text));
            }

            _text = text;
        }

        public static implicit operator string(Gossip gossip) =>
            gossip._text;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _text;
        }
    }
}