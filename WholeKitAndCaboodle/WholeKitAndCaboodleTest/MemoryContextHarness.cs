using Shouldly;
using WholeKitAndCaboodle;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class MemoryContextHarness
    {
        [Fact]
        public void ShouldReturnMemoryContextObject()
        {
            var actual = MemoryContext.Context();
            actual.ShouldBeOfType(typeof(MemoryContext));
        }

        [Fact]
        public void ShouldReturnDataFromContext()
        {
            var context = MemoryContext.Context();
            context.GetDataString().ShouldNotBeEmpty();
        }
    }
}