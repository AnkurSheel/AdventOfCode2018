using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2018.Tests.Day1
{
	public class ChronalCalibrationTest
	{
		private readonly ChronalCalibration _calibration;

		public ChronalCalibrationTest()
		{
			_calibration = new ChronalCalibration();
		}

		[Theory]
		[JsonFileData("Day1/testData.json", "Part1", typeof(int), typeof(int))]
		public void CalibrateReturnsCorrectFrequency(List<int> data, int expectedResult)
		{
			var result = _calibration.CalibratePart1(data);
			Assert.Equal(expectedResult, result);
		}

		[Theory]
		[JsonFileData("Day1/testData.json", "Part2", typeof(int), typeof(int))]
		public void CalibrateReturnsCorrectFrequencyItReachesTwice(List<int> data, int expectedResult)
		{
			var result = _calibration.CalibratePart2(data);
			Assert.Equal(expectedResult, result);
		}
	}
}
