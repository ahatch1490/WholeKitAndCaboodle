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
            var profiles = d.GetProfiles();
            profiles.ShouldNotBeEmpty();
        }

        [Fact]
        public void BeAbleToReuseMemoryStream()
        {
            using (var d = new DataManager())
            {
                for (var i = 0; i < 10; i++)
                {
                    var data = d.GetRawData();
                    data.ShouldNotBeNull();
                    data.ShouldNotBeEmpty();
                }
            }
        }

        [Fact]
        public void ShouldReturnStringOfData()
        {
            using (var manager = new DataManager())
            {
                manager.GetData(DataType.FirstNameLastName).ShouldNotBeEmpty();
            }
        }
    }
}