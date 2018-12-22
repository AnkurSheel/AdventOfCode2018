namespace AdventOfCode2018.Tests.Day3
{
    public class Claim
    {
        public Claim(int id, Coordinate topLeft, Coordinate bottomRight)
        {
            Id = id;
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Coordinate BottomRight { get; }

        public int Id { get; }

        public Coordinate TopLeft { get; }

        public bool IsOverlap(Claim otherClaim)
        {
            return !(otherClaim.BottomRight.X < TopLeft.X
                     || otherClaim.BottomRight.Y < TopLeft.Y
                     || BottomRight.X < otherClaim.TopLeft.X
                     || BottomRight.Y < otherClaim.TopLeft.Y);
        }
    }
}