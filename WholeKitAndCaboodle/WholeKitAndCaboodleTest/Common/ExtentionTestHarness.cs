using Xunit;
using WholeKitAndCaboodle.Common;
using Shouldly;
using WholeKitAndCaboodle.Common;
namespace WholeKitAndCaboodleTest.Common
{
    public class ExtentionTestHarness
    {
        [Fact]
        public void ShouldRemoveBeginningAndEndQuotes()
        {

            const string expected = "foo";
            "\"foo\"".TrimQuotes().ShouldBe(expected);
        }
    }
}