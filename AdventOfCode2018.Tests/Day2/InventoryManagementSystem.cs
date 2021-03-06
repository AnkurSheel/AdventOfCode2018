﻿using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Tests.Day2
{
    public class InventoryManagementSystem
    {
        public int CalculateChecksum(List<string> boxIds)
        {
            var twiceAppearingLetterCount = 0;
            var thriceAppearingLetterCount = 0;

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

                var twiceAppearingLetterFound = false;
                var thriceAppearingLetterFound = false;
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

        public string CalculateCommonIdDifferingByOneChar(List<string> boxIds)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < boxIds.Count; i++)
            {
                var id1 = boxIds[i];
                for (var j = i + 1; j < boxIds.Count; j++)
                {
                    sb.Clear();
                    var id2 = boxIds[j];
                    var charDifferencesFound = 0;
                    for (int k = 0, l = 0; k < id1.Length && l < id2.Length; k++, l++)
                    {
                        if (id1[k] == id2[l])
                        {
                            sb.Append(id1[k]);
                        }
                        else
                        {
                            charDifferencesFound++;
                            if (charDifferencesFound > 1)
                            {
                                break;
                            }
                        }
                    }

                    if (charDifferencesFound == 1)
                    {
                        return sb.ToString();
                    }
                }
            }

            return string.Empty;
        }
    }
}