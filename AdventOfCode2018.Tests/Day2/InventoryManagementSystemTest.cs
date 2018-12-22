using System.Collections.Generic;

using Xunit;

namespace AdventOfCode2018.Tests.Day2
{
    public class InventoryManagementSystemTest
    {
        private readonly InventoryManagementSystem _inventoryManagementSystem;

        public InventoryManagementSystemTest()
        {
            _inventoryManagementSystem = new InventoryManagementSystem();
        }

        [Theory]
        [JsonFileData("Day2/testData.json", "Part1", typeof(List<string>), typeof(int))]
        public void CalculateChecksumReturnsCorrectChecksum(List<string> boxIds, int expectedResult)
        {
            var result = _inventoryManagementSystem.CalculateChecksum(boxIds);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [JsonFileData("Day2/testData.json", "Part2", typeof(List<string>), typeof(string))]
        public void CalculateCommonIdDifferingByOneCharReturnsCorrectString(List<string> boxIds, string expectedResult)
        {
            var result = _inventoryManagementSystem.CalculateCommonIdDifferingByOneChar(boxIds);
            Assert.Equal(expectedResult, result);
        }
    }
}