using System.Collections.Generic;

namespace WholeKitAndCaboodle.Common
{
    public interface IRandomNumberGenerator
    {
        List<int> GetListOfNumbers(int size, Range range);
        int GetRandomIntegerBetween(int first, int second);
        int GetRandomIntegerBetween(Range range);
        char GetRandomLetterUpper();
        char GetRandomLetterLower();
    }
}