using System;
using Moq;
using Xunit;
using WholeKitAndCaboodle;
using Shouldly;

namespace WholeKitAndCaboodleTest
{
    public class VehicleDataServiceHarness
    {
        private Mock<IDataManager> _dataManager = new Mock<IDataManager>();
        private Mock<IRandomNumberGenerator> _randomNumberGenerator = new Mock<IRandomNumberGenerator>();
        public VehicleDataServiceHarness()
        {
         
        }
        [Fact]
        public void ShouldGetAListOfVehicles()
        {
            var data = "\"Y6966Y5387050F976\",172307,2008,\"Subaru\",\"Tribeca\",10061.44,13582.95,1.47,\"Limited 5-Pass 4dr SUV AWD w/Nav (3.6L 6cyl 5A)\",\"Bad Underhood Belts/Hoses/\"";

            var service = new VehicleDataService(_dataManager.Object, _randomNumberGenerator.Object);
            _dataManager.Setup(x => x.GetData(DataType.Vehicle)).Returns(data);
            service.GetVehicleData().ShouldNotBeEmpty();
        }
    }
}

