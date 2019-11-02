using Shouldly;
using WholeKitAndCaboodle;
using Xunit;
namespace WholeKitAndCaboodleTest
{
    public class DataManagerHarness
    {
        [Fact]
        public void BeAbleToGetAddressData()
        {
            var d = new DataManager();
            var addresses = d.GetAddressesDataUS();
            addresses.ShouldNotBeEmpty();
        }
    }
}