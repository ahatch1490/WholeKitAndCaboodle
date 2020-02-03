using System;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Xunit;
using Moq;
using Shouldly;
using WholeKitAndCaboodle;

namespace WholeKitAndCaboodleTest
{
    public class AddressServiceHarness
    {
        private IMock<IRandomNumberGenerator> _moqRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        private IMock<IDataManager> _moqDatamanager = new Mock<IDataManager>();
        [Fact]
        public void GetAddressNumber()
        {
            var addressService = new AddressService(new DataManager(),new RandomNumberGenerator());
            addressService.GetAddressNumber();
        }

        [Fact]
        public void ShouldReturnAStreetName()
        {
            var addressService = new AddressService(new DataManager(), new RandomNumberGenerator());
            addressService.Street().ShouldNotBeNull();
        }

        [Fact]
        public void ShouldReturnAFullAddress()
        {
            var addressService = new AddressService(new DataManager(), new RandomNumberGenerator());
            addressService.Street().ShouldNotBeNull();
            addressService.GetAddressNumber().ShouldNotBeNull();
            addressService.GetCity().ShouldNotBeNull();
            addressService.GetStateAbbreviation().ShouldNotBeNull();
            addressService.GetZip().ShouldNotBeNull();
        }
        
    }
}