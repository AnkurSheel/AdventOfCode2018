using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests.Day2
{
	public class InventoryManagementSystem
	{
		public int CalculateChecksum(List<string> boxIds)
		{
			int twiceAppearingLetterCount = 0;
			int thriceAppearingLetterCount = 0;

			foreach (var id in boxIds)
			{
				var seenLetters = new Dictionary<char, int>();
				foreach (var letter in id)
				{
					if (seenLetters.ContainsKey(letter))
					{
						seenLetters[letter] += 1;
					}
					else
					{
						seenLetters[letter] = 1;
					}
				}

				bool twiceAppearingLetterFound = false;
				bool thriceAppearingLetterFound = false;
				foreach (var letterCounts in seenLetters)
				{
					if (!twiceAppearingLetterFound && letterCounts.Value == 2)
					{
						twiceAppearingLetterCount++;
						twiceAppearingLetterFound = true;
					}
					if (!thriceAppearingLetterFound && letterCounts.Value == 3)
					{
						thriceAppearingLetterCount++;
						thriceAppearingLetterFound = true;
					}
				}
			}

			return twiceAppearingLetterCount * thriceAppearingLetterCount;
		}
	}
}