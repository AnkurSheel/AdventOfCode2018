
using System;
using System.Collections.Generic;

using AdventOfCode2018.Tests.Helpers;

using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2018.Tests.Day6
{
    public class ChronalCoordinatesTests
    {
        private readonly ChronalCoordinates _chronalCoordinates;

        public ChronalCoordinatesTests(ITestOutputHelper outputHelper)
        {
            Console.SetOut(new Converter(outputHelper));
            _chronalCoordinates = new ChronalCoordinates();
        }

        [Theory]
        [JsonFileData("Day6/testData.json", "Part1", typeof(List<string>), typeof(int))]
        public void GetSizeOfLargestAreaThatIsntInfiniteReturnsCorrectSize(List<string> coordinates, int expectedResult)
        {
            var result = _chronalCoordinates.GetSizeOfLargestAreaThatIsntInfinite(coordinates);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [JsonFileData("Day6/testData.json", "Part2", typeof(List<string>), typeof(int))]
        public void GetSizeOfLargestAreaNearAsManyCoordinatesAsPossibleReturnsCorrectSize(List<string> coordinates, int expectedResult)
        {
            var result = _chronalCoordinates.GetSizeOfLargestAreaNearAsManyCoordinatesAsPossible(coordinates);
            Assert.Equal(expectedResult, result);
        }
    }
}