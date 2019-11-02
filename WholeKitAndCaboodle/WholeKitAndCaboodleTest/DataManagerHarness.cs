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
        
        [Fact]
        public void BeAbleToGetProfileData()
        {
            var d = new DataManager();
            var profiles = d.GetProcfiles();
            profiles.ShouldNotBeEmpty();
        }
    }
}