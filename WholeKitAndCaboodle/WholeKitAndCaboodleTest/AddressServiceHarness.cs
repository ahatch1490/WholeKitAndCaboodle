using System;
using Xunit;
using Moq;
using WholeKitAndCaboodle;

namespace WholeKitAndCaboodleTest
{
    public class AddressServiceHarness
    {
        public IMock<IRandomNumberGenerator> _RandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        public IMock<IDataManager> _datamanager = new Mock<IDataManager>();
        [Fact]
        public void GetAddressNumber()
        {
            var addressService = new AddressService(_datamanager.Object,_RandomNumberGenerator.Object);
            addressService.GetAddressNumber();
        }
        
    }
}