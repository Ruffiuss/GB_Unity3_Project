using System;

namespace RollABall
{
    internal class DefaultFromSelfAttribute : Attribute
    {
        public bool UseEntity { get; set; }
    }
}