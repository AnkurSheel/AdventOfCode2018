using System.Diagnostics;

namespace AdventOfCode2018.Tests.Helpers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Coordinate
    {
        public Coordinate()
        {
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        private string DebuggerDisplay => $"X: {X}, Y: {Y}";

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Coordinate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        protected bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}