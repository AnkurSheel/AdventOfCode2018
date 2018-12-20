using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests.Day3
{
    public class NoMatterHowYouSliceIt
    {
        private List<Claim> _claims;

        private HashSet<Coordinate> _overlappingCoordinates;

        public int GetTotalOverlappingCoordinatesCount(List<string> rawClaims)
        {
            _claims = new List<Claim>(rawClaims.Count);
            _overlappingCoordinates = new HashSet<Coordinate>();

            foreach (var rawClaim in rawClaims)
            {
                var newClaim = ParseClaim(rawClaim);
                GetOverlappingAreas(newClaim);

                _claims.Add(newClaim);
            }

            return _overlappingCoordinates.Count;
        }

        private void GetOverlappingAreas(Claim newClaim)
        {
            foreach (var claim in _claims)
            {
                if (newClaim.IsOverlap(claim))
                {
                var topLeft = new Coordinate();
                var bottomRight = new Coordinate();

                SetXCoordinates(newClaim, claim, bottomRight, topLeft);

                SetYCoordinates(newClaim, claim, bottomRight, topLeft);

                SetOverlappingCoordinates(topLeft, bottomRight);
            }
        }
        }

        private Claim ParseClaim(string rawClaim)
        {
            var tokens = rawClaim.Split(new[] { ' ', '#', '@', ':', ',', 'x' }, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(tokens[0]);
            var leftEdge = int.Parse(tokens[1]);
            var topEdge = int.Parse(tokens[2]);
            var width = int.Parse(tokens[3]);
            var height = int.Parse(tokens[4]);

            var claim = new Claim(id, new Coordinate(leftEdge, topEdge), new Coordinate(leftEdge + width - 1, topEdge + height - 1));
            return claim;
        }

        private void SetOverlappingCoordinates(Coordinate topLeft, Coordinate bottomRight)
        {
            for (var i = topLeft.X; i <= bottomRight.X; i++)
            {
                for (var j = topLeft.Y; j <= bottomRight.Y; j++)
                {
                    _overlappingCoordinates.Add(new Coordinate(i, j));
                }
            }
        }

        private void SetXCoordinates(Claim claim1, Claim claim2, Coordinate bottomRight, Coordinate topLeft)
        {
            if (claim1.BottomRight.X > claim2.BottomRight.X)
            {
                bottomRight.X = claim2.BottomRight.X;
                topLeft.X = claim1.TopLeft.X < claim2.TopLeft.X ? claim2.TopLeft.X : claim1.TopLeft.X;
            }
            else
            {
                bottomRight.X = claim1.BottomRight.X;
                topLeft.X = claim2.TopLeft.X < claim1.TopLeft.X ? claim1.TopLeft.X : claim2.TopLeft.X;
            }
        }

        private void SetYCoordinates(Claim claim1, Claim claim2, Coordinate bottomRight, Coordinate topLeft)
        {
            if (claim1.BottomRight.Y > claim2.BottomRight.Y)
            {
                bottomRight.Y = claim2.BottomRight.Y;
                topLeft.Y = claim1.TopLeft.Y < claim2.TopLeft.Y ? claim2.TopLeft.Y : claim1.TopLeft.Y;
            }
            else
            {
                bottomRight.Y = claim1.BottomRight.Y;
                topLeft.Y = claim2.TopLeft.Y < claim1.TopLeft.Y ? claim1.TopLeft.Y : claim2.TopLeft.Y;
            }
        }
    }
}