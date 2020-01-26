using System;
using Xunit;
using Moq;
using WholeKitAndCaboodle;

namespace WholeKitAndCaboodleTest
{
    public class AddressServiceHarness
    {
        public IMock<IRandomNumberGenerator> _RandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        [Fact]
        public void GetAddressNumber()
        {
            var addressService = new AddressService();
            addressService.GetAddressNumber();
        }
        
    }
}