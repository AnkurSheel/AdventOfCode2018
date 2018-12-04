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
		[JsonFileData("Day2/testData.json", "Part1", typeof(string), typeof(int))]
		public void CalculateChecksumReturnsCorrectChecksum(List<string> data, int expectedResult)
		{
			var result = _inventoryManagementSystem.CalculateChecksum(data);
			Assert.Equal(expectedResult, result);
		}
	}
}