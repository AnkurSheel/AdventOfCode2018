using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode2018.Tests.Helpers;

namespace AdventOfCode2018.Tests.Day6
{
    public class ChronalCoordinates
    {
        private Coordinate[] _coordinates;

        public int GetSizeOfLargestAreaThatIsntInfinite(List<string> rawCoordinates)
        {
            Array.Resize(ref _coordinates, rawCoordinates.Count);

            ParseRawCoordinates(rawCoordinates);

            var bottomRight = GetBottomRightCoordinate();

            var distances = GetClosestPointMatrix(bottomRight);

            var nearestPoints = GetEnclosedNearestPoints(bottomRight, distances);
            return nearestPoints.First().Value;
        }

        private Dictionary<Coordinate, int> GetEnclosedNearestPoints(Coordinate bottomRight, ClosestCoordinate[,] distances)
        {
            var nearestPoints = _coordinates.ToDictionary(coordinate => coordinate, coordinate => 0);

            for (var j = 0; j <= bottomRight.Y; j++)
            {
                for (var i = 0; i <= bottomRight.X; i++)
                {
                    var coordinate = distances[j, i].BestPoint;
                    if (coordinate != null && nearestPoints.ContainsKey(coordinate))
                    {
                        if (i == 0 || j == 0 || i == bottomRight.X || j == bottomRight.Y)
                        {
                            nearestPoints.Remove(coordinate);
                        }
                        else
                        {
                            nearestPoints[coordinate]++;
                        }
                    }
                }
            }

            nearestPoints = new Dictionary<Coordinate, int>(nearestPoints.OrderByDescending(n => n.Value));
            return nearestPoints;
        }

        private ClosestCoordinate[,] GetClosestPointMatrix(Coordinate bottomRight)
        {
            var distances = new ClosestCoordinate[bottomRight.Y + 1, bottomRight.X + 1];

            foreach (var coordinate in _coordinates)
            {
                for (var j = 0; j <= bottomRight.Y; j++)
                {
                    for (var i = 0; i <= bottomRight.X; i++)
                    {
                        var diffX = Math.Abs(coordinate.X - i);
                        var diffY = Math.Abs(coordinate.Y - j);

                        long distance = diffX + diffY;
                        var currentPoint = new Coordinate(i, j);
                        if (distances[j, i] == null)
                        {
                            distances[j, i] = new ClosestCoordinate { Point = currentPoint };
                        }

                        if (distances[j, i].BestDistance > distance)
                        {
                            distances[j, i].BestPoint = coordinate;
                            distances[j, i].BestDistance = distance;
                        }
                        else if (distances[j, i].BestDistance == distance)
                        {
                            distances[j, i].BestPoint = null;
                            distances[j, i].BestDistance = distance;
                        }
                    }
                }
            }

            return distances;
        }

        private Coordinate GetBottomRightCoordinate()
        {
            var bottomRight = new Coordinate();
            foreach (var coordinate in _coordinates)
            {
                if (bottomRight.X < coordinate.X)
                {
                    bottomRight.X = coordinate.X + 1;
                }

                if (bottomRight.Y < coordinate.Y)
                {
                    bottomRight.Y = coordinate.Y + 1;
                }
            }

            return bottomRight;
        }

        private void ParseRawCoordinates(List<string> rawCoordinates)
        {
            for (var i = 0; i < rawCoordinates.Count; i++)
            {
                var rawCoordinate = rawCoordinates[i];
                var tokens = rawCoordinate.Split(',', StringSplitOptions.RemoveEmptyEntries);
                _coordinates[i] = new Coordinate(int.Parse(tokens[0]), int.Parse(tokens[1]));
            }
        }
    }
}