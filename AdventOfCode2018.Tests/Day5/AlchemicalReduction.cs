using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests.Day5
{
    public class AlchemicalReduction
    {
        private const int DifferenceBetweenLowerAndUpperCase = 32;

        public int GetRemainingUnits(string polymer)
        {
            var stack = new Stack<char>();
            foreach (var unit in polymer)
            {
                if (stack.Count == 0)
                {
                    stack.Push(unit);
                }
                else
                {
                    var lastChar = stack.Peek();
                    if (Math.Abs(unit - lastChar) == DifferenceBetweenLowerAndUpperCase)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(unit);
                    }
                }
            }

            return stack.Count;
        }
    }
}