using System.ComponentModel.DataAnnotations;
using Shouldly;
using WholeKitAndCaboodle;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class LoremIpsumTest
    {
        [Fact]
        public void ShouldReturnAParagraph()
        {
            var service = new LoremIpsumService(new DataManager(), new RandomNumberGenerator());
            var actual = service.GetParagraph();
            actual.Length.ShouldBeGreaterThan(20);
        }
    }
}