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
            string actual = generator.PadLeftValue(length, value);
            
            actual.ShouldBe("111111");
        }

        [Fact]
        public void ShouldHandleNegativeWithEmptyString()
        {
            var generator = new PaddedValueGenerator(_randomNumberGenerator.Object);
            int length = 6;
            int value = -1;
            string actual = generator.PadLeftValue(length, value);
            
            actual.ShouldBe("");
        }
        
        [Fact]
        public void ShouldPadToLengthOfSix()
        {
            var generator = new PaddedValueGenerator(_randomNumberGenerator.Object);
            int length = 6;
            int value = 1;
            string actual = generator.PadLeftValue(length, value);
            
            actual.ShouldBe("000001");
        }
        
        [Fact]
        public void ShouldPadToLength4()
        {
            var generator = new PaddedValueGenerator(_randomNumberGenerator.Object);
            int length = 8;
            int value = 1111;
            string actual = generator.PadLeftValue(length, value);
            
            actual.ShouldBe("00001111");
        }
        
        
        
    }
}