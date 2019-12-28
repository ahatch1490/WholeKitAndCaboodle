using System.Collections.Generic;
using System.ComponentModel;

namespace WholeKitAndCaboodle
{
    public class RandomNumberGenerator: IRandomNumberGenerator
    {
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

        public char GetRandomLetterUpper()
        {
            return (char) this.GetRandomIntegerBetween(65,90);
        }
        public char GetRandomLetterLower()
        {
            return (char) this.GetRandomIntegerBetween(97,122);
        }
    }
}