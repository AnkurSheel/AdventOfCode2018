using Xunit;

namespace AdventOfCode2018.Tests.Day5
{
    public class AlchemicalReductionTests
    {
        private readonly AlchemicalReduction _alchemicalReduction;

        public AlchemicalReductionTests()
        {
            _alchemicalReduction = new AlchemicalReduction();
        }

        [Theory]
        [JsonFileData("Day5/testData.json", "Part1", typeof(string), typeof(int))]
        public void GetRemainingUnitsReturnsCorrectNumberOfUnits(string polymer, int expectedResult)
        {
            var result = _alchemicalReduction.GetRemainingUnits(polymer);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [JsonFileData("Day5/testData.json", "Part2", typeof(string), typeof(int))]
        public void GetRemainingUnitsAfterImprovingPolymerReturnsCorrectNumberOfUnits(string polymer, int expectedResult)
        {
            var result = _alchemicalReduction.GetRemainingUnitsAfterImprovingPolymer(polymer);
            Assert.Equal(expectedResult, result);

        }
    }
}