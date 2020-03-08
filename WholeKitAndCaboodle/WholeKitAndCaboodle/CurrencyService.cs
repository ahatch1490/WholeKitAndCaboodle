using System;
using System.Net.NetworkInformation;

namespace WholeKitAndCaboodle
{
    public class CurrencyService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public CurrencyService(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public decimal GetAmount(Range range)
        {
            var change =  .01m * _randomNumberGenerator.GetRandomIntegerBetween(0,99);
            var dollar = _randomNumberGenerator.GetRandomIntegerBetween(range.Start, range.End);
            return dollar + change;
        }
    }
}