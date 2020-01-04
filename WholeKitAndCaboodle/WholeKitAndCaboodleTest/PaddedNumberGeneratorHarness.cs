using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Shouldly;
using WholeKitAndCaboodle;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class PaddedNumberGeneratorHarness
    {
        Mock<IRandomNumberGenerator> _randomNumberGenerator = new Mock<IRandomNumberGenerator>();

        [Fact]
        public void ShouldJustReturnNumberIfItDoesNotNeedPAdding()
        {
            var generator = new PaddedValueGenerator(_randomNumberGenerator.Object);
            int length = 6;
            int value = 111111;
            string actual = generator.PadValue(length, value);
            
            actual.ShouldBe("111111");
            
        }
        
    }
}