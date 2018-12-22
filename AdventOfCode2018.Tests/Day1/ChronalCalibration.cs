using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Tests.Day1
{
    public class ChronalCalibration
    {
        public int CalibratePart1(List<int> data)
        {
            return data.Sum();
        }

        public int CalibratePart2(List<int> frequencies)
        {
            var seenFrequency = new HashSet<int>();
            var total = 0;
            seenFrequency.Add(total);
            while (true)
            {
                foreach (var frequency in frequencies)
                {
                    total += frequency;
                    if (seenFrequency.Contains(total))
                    {
                        return total;
                    }

                    seenFrequency.Add(total);
                }
            }
        }
    }
}