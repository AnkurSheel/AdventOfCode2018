using System.Collections.Generic;

namespace AdventOfCode2018.Tests.Day4
{
    public class Record
    {
        public Record()
        {
            SleepMinutes = new Dictionary<int, int>();
        }

        public Record(Record recordValue)
        {
            GuardId = recordValue.GuardId;
            TotalSleepTime = recordValue.TotalSleepTime;
            SleepMinutes = recordValue.SleepMinutes;
            SleepTime = recordValue.SleepTime;
            WakeTime = recordValue.WakeTime;
        }


        public int GuardId { get; set; }

        public int TotalSleepTime { get; set; }

        public Dictionary<int, int> SleepMinutes { get; }

        public int SleepTime { get; set; }

        public int WakeTime { get; set; }
    }
}