using System.Collections.Generic;

using Xunit;

namespace AdventOfCode2018.Tests.Day4
{
    public class ReposeRecordTests
    {
        private readonly ReposeRecord _reposeRecord;

        public ReposeRecordTests()
        {
            _reposeRecord = new ReposeRecord();
        }

        [Theory]
        [JsonFileData("Day4/testData.json", "Part1", typeof(string), typeof(int))]
        public void GetMostMinutesAsleepGuardIdMultipliedByTheMinuteTheGuardSpendsAsleepMostReturnsCorrectResult(List<string> records, int expectedResult)
        {
            var result = _reposeRecord.GetMostMinutesAsleepGuardIdMultipliedByTheMinuteTheGuardSpendsAsleepMost(records);
            Assert.Equal(expectedResult, result);
        }
    }
}