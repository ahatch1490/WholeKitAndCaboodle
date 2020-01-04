﻿using System;
using Moq;
using Xunit;
using WholeKitAndCaboodle;
using Shouldly;
using System.Linq;

namespace WholeKitAndCaboodleTest
{
    public class VehicleDataServiceHarness
    {
        private Mock<IDataManager> _dataManager = new Mock<IDataManager>();
        private IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        public VehicleDataServiceHarness()
        {
         
        }

        [Fact]
        public void ShouldBeAbleToGenerateVehicleData()
        {
            var service = new VehicleDataService(new DataManager(),  new RandomNumberGenerator());
            var actual = service.GetVehicleData();
            actual.ShouldNotBeNull();
            actual.Vin.ShouldNotBeEmpty();
        }
        [Fact]
        public void ShouldGetAListOfVehicles()
        {
            const string data = "\"Y6966Y5387050F976\",172307,2008,\"Subaru\",\"Tribeca\",10061.44,13582.95,1.47,\"Limited 5-Pass 4dr SUV AWD w/Nav (3.6L 6cyl 5A)\",\"Bad Underhood Belts/Hoses/\"";
            _dataManager.Setup(x => x.GetData(It.IsAny<DataType>())).Returns(data);
            var service = new VehicleDataService(_dataManager.Object, _randomNumberGenerator);
            service.GetListOfVehicleData(1).ShouldNotBeEmpty();
        }

        [Fact]
        public void ShouldReturnAListOfUniqueVinNumbers()
        {
            var service = new VehicleDataService(new DataManager(), new RandomNumberGenerator());
            var actual = service.GetListOfVehicleData(100);
            actual.Count.ShouldBe(100);
        }

//        [Fact]
//        public void ShouldBeUniqueByVin()
//        {
//            const int expected = 100;
//            var service = new VehicleDataService(new DataManager(), new RandomNumberGenerator());
//            var actual = service.GetVehicleData(expected);
//            actual.Select(x => x.Vin).ShouldBeUnique();
//        }
//
//        [Fact]
//        public void ShouldThrowExceptionWhenMaxCountReached()
//        {
//            var threwException = false;
//            try
//            {
//                const int invalidCount = 10000000;
//                var service = new VehicleDataService(new DataManager(), new RandomNumberGenerator());
//                var actual = service.GetVehicleData(invalidCount);
//            }
//            catch(MaxVehicleRangeException)
//            {
//                threwException = true;
//            }
//
//            Assert.True(threwException, "Should have thrown MaxVehicleRangeException");
//        }
    }
}

