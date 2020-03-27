using Shouldly;
using WholeKitAndCaboodle;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class CurrencyServiceHarness
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        
        [Fact]
        public void ShouldReturnCurrency()
        {
            var service = new CurrencyService(_randomNumberGenerator);
            var amount = service.GetAmount(new Range(0, 1));
            amount.ShouldBeGreaterThan(0);
            amount.ShouldBeLessThan(1);
        }
    }
}