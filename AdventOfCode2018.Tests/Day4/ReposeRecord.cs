using System;
using System.Collections.Generic;
using System.Globalization;

namespace AdventOfCode2018.Tests.Day4
{
    public class ReposeRecord
    {
        private int _currentGuardId;

        private DateTime _currentGuardSleepTime;

        private DateTime _currentGuardStartTime;

        private SortedDictionary<DateTime, Record> _records;

        public int GetMostMinutesAsleepGuardIdMultipliedByTheMinuteTheGuardSpendsAsleepMost(List<string> rawRecords)
        {
            _records = new SortedDictionary<DateTime, Record>();

            var sortedRecords = new SortedDictionary<DateTime, string>();

            foreach (var rawRecord in rawRecords)
            {
                var tokens = rawRecord.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                var dateTime = DateTime.ParseExact(tokens[0], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                sortedRecords.Add(dateTime, rawRecord);
            }

            foreach (var (recordTimestamp, sortedRecord) in sortedRecords)
            {
                ParseRawRecords(recordTimestamp, sortedRecord);
            }

            var bestGuard = GetGuardThatHasMostMinutesAsleep();

            var mostAsleepMinute = 0;
            var timesAsleepAtMostAsleepMinute = 0;
            foreach (var (sleepMinute, timesAsleepAtMinute) in bestGuard.SleepMinutes)
            {
                if (timesAsleepAtMostAsleepMinute < timesAsleepAtMinute)
                {
                    mostAsleepMinute = sleepMinute;
                    timesAsleepAtMostAsleepMinute = timesAsleepAtMinute;
                }
            }

            return bestGuard.GuardId * mostAsleepMinute;
        }

        private Record GetGuardThatHasMostMinutesAsleep()
        {
            var bestGuard = new Record();

            var guards = new Dictionary<int, Record>();
            foreach (var (_, record) in _records)
            {
                var guardId = record.GuardId;
                Record guard;
                if (!guards.ContainsKey(guardId))
                {
                    guard = new Record(record);
                    guards.Add(guardId, guard);
                }
                else
                {
                    guard = guards[guardId];
                    guard.TotalSleepTime += record.TotalSleepTime;

                    foreach (var sleepMinute in record.SleepMinutes)
                    {
                        var sleepMinuteKey = sleepMinute.Key;
                        if (guard.SleepMinutes.ContainsKey(sleepMinuteKey))
                        {
                            guard.SleepMinutes[sleepMinuteKey]++;
                        }
                        else
                        {
                            guard.SleepMinutes.Add(sleepMinuteKey, 1);
                        }
                    }
                }

                if (bestGuard.TotalSleepTime <= guard.TotalSleepTime)
                {
                    bestGuard = guard;
                }
            }

            return bestGuard;
        }

        private void ParseRawRecords(DateTime timeStamp, string rawRecord)
        {
            var tokens = rawRecord.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            Record entry;
            var recordExists = false;
            if (_records.ContainsKey(timeStamp.Date))
            {
                recordExists = true;
                entry = _records[timeStamp.Date];
            }
            else
            {
                entry = new Record();
                _records.Add(timeStamp.Date, entry);
            }

            if (tokens[1].StartsWith(" Guard"))
            {
                var t = tokens[1].Split(new[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                _currentGuardId = int.Parse(t[1]);

                if (recordExists && _currentGuardStartTime.Date == timeStamp.Date)
                {
                    timeStamp = timeStamp.AddDays(1).Date;
                    _currentGuardStartTime = timeStamp;
                    entry = new Record { GuardId = _currentGuardId };
                    _records.Add(timeStamp.Date, entry);
                }
                else
                {
                    entry.GuardId = _currentGuardId;
                    _currentGuardStartTime = timeStamp;
                }
            }
            else if (tokens[1].StartsWith(" falls"))
            {
                _currentGuardSleepTime = timeStamp;
            }
            else
            {
                var wakeTime = timeStamp.Minute;
                entry.TotalSleepTime += wakeTime - _currentGuardSleepTime.Minute;
                for (var k = _currentGuardSleepTime.Minute; k < wakeTime; k++)
                {
                    entry.SleepMinutes.Add(k, 1);
                }
            }
        }
    }
}