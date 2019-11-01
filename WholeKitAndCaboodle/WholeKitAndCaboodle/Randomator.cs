using System;
using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class Randomator
    {
        public int GetRandomIntegerBetween(Range range)
        {
            return GetRandomIntegerBetween(range.Start, range.End);
        }
        
        public int GetRandomIntegerBetween(int first, int second)
        {
            var random = new System.Random();
            return random.Next(first, second);
        }

        public List<int> GetListOfNumbers(int size, Range range)
        {
            List<int> list = new List<int>();
            for(var i = 0; i < size; i++)
            {
                list.Add(  this.GetRandomIntegerBetween(range.Start, range.End));
            }
            return list;
        }
    }
}