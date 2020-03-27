using System;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Xunit;
using Moq;
using Shouldly;
using WholeKitAndCaboodle;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

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
        
        [Fact]
        public void ShouldGetZip()
        {
            var addressService = new AddressService(new DataManager(), new RandomNumberGenerator());
            addressService.GetZip().ShouldNotBeNull();
        }
        
        
        [Fact]
        public void ShouldGetZipByState()
        {
            var addressService = new AddressService(new DataManager(), new RandomNumberGenerator());
            var zip = addressService.GetZip("WA");
            zip.ShouldContain("990");
        }

        [Fact]
        public void ShouldGetValesFromFacade()
        {
            USAddress.GetStreet().Length.ShouldBeGreaterThan(0);
            USAddress.GetStateAbbreviation().Length.ShouldBe(2);
            USAddress.GetZipCode().Length.ShouldBe(5);
            USAddress.GetCityCode().Length.ShouldBeGreaterThan(0);
            USAddress.GetAddressNumber().Length.ShouldBeGreaterThan(0); 
        }
        
    }
}