using Shouldly;
using WholeKitAndCaboodle;
using Xunit;
using Range = WholeKitAndCaboodle.Common.Range;

namespace WholeKitAndCaboodleTest
{
    public class RandomatorTestHarness
    {
        private Randomator _randomator = new Randomator();
        [Fact]
        public void ShouldReturnARandomStringValue()
        {
            var actual = _randomator.GetRandomIntegerBetween(0, 99);
            actual.ShouldBeInRange(0,99);  
        }

        [Fact]
        public void ShouldReturnArrayOfSpecifiedSize()
        {
            int size = 10;
            var randomNumbers = _randomator.GetListOfNumbers(size, new Range(1, 10));
            randomNumbers.Count.ShouldBe(10);
        }

        [Fact]
        public void ShouldReturnAListOfNumbersLessBetween1And10()
        {
            int size = 10;
            var randomNumbers = _randomator.GetListOfNumbers(size, new Range(1, 10));
            randomNumbers.ShouldAllBe((x) => x < 11 && x > 0);
        }
 
        [Fact]
        public void ShouldReturnUserProfileList()
        {
            var actual = _randomator.GetUserProfiles(99);
            actual.Count.ShouldBe(99);
        }
        
    }
}