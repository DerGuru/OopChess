using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess
{
    public enum XLocation
    {
        A, B, C, D, E, F, G, H
    }

    public enum YLocation
    {
        _1, _2, _3, _4, _5, _6, _7, _8
    }

    public class Location
    {
        public XLocation X { get; set; }
        public YLocation Y { get; set; }

        public override bool Equals(object obj)
        {
            var loc = obj as Location;
            if (loc == null)
                return false;

            return loc.X == X && loc.Y == Y;
        }

        public override int GetHashCode()
        {
            return (int)X * 10 + (int)Y;
        }

        public override string ToString()
        {
            return $"X: {X.ToString()}, Y: {Y.ToString()}";
        }
    }
}
