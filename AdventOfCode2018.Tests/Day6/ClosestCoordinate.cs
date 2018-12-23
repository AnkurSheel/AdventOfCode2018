using AdventOfCode2018.Tests.Helpers;

internal class ClosestCoordinate
{
    public ClosestCoordinate()
    {
        BestDistance = int.MaxValue;
    }

    public Coordinate Point { get; set; }

    public Coordinate BestPoint { get; set; }

    public long BestDistance { get; set; }
}