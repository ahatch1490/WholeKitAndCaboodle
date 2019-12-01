using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public interface IRandomNumberGenerator
    {
        List<int> GetListOfNumbers(int size, Range range);
        int GetRandomIntegerBetween(int first, int second);
    }
}