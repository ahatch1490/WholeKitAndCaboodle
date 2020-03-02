using Moq;
using Shouldly;
using WholeKitAndCaboodle;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class ColorServiceHarness
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        
        [Fact]
        public void ShouldReturnRGBColor()
        {
            var service = new ColorService(_randomNumberGenerator);
            var rgb = service.GetRGBColorArray();
            rgb.Length.ShouldBe(3);
        }
    }
}