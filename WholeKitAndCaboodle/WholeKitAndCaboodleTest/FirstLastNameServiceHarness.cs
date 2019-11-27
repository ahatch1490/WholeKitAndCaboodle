﻿using System;
using Moq;
using WholeKitAndCaboodle;
using Xunit;
using Shouldly;

namespace WholeKitAndCaboodleTest
{
    public class FirstLastNameServiceHarness
    {
        private Mock<IDataManager> _dataManager = new Mock<IDataManager>();
        private Mock<IRandomNumberGenerator> _randomNumberGenerator = new Mock<IRandomNumberGenerator>();

        [Fact]
        public void ShouldReturnListOfFirstNames()
        {
            var firstnames = $"firstname,lastname{Environment.NewLine}firstname1,lastname1";
            _dataManager.Setup(x => x.GetData(It.IsAny<DataType>())).Returns(firstnames);
            var service = new FirstLastNameService(_dataManager.Object, _randomNumberGenerator.Object);
            var actual = service.GetFirstNames();
            actual.ShouldNotBeNull();
            actual.ShouldNotBeEmpty();
        }

        [Fact]
        public void ShouldHaveTwoFirstNames()
        {
            var firstnames = $"firstname,lastname{Environment.NewLine}firstname1,lastname1";
            _dataManager.Setup(x => x.GetData(It.IsAny<DataType>())).Returns(firstnames);
            var service = new FirstLastNameService(_dataManager.Object, _randomNumberGenerator.Object);
            var actual = service.GetFirstNames();
            actual.Count.ShouldBeGreaterThanOrEqualTo(2);
        }

        [Fact]
        public void ShouldReturnListOfLastNames()
        {
            var firstnames = $"firstname,lastname{Environment.NewLine}firstname1,lastname1";
            _dataManager.Setup(x => x.GetData(It.IsAny<DataType>())).Returns(firstnames);
            var service = new FirstLastNameService(_dataManager.Object, _randomNumberGenerator.Object);
            var actual = service.GetLastNames();
            actual.ShouldNotBeNull();
            actual.ShouldNotBeEmpty();
        }

        [Fact]
        public void ShouldHaveTwoLastNames()
        {
            var firstnames = $"firstname,lastname{Environment.NewLine}firstname1,lastname1";
            _dataManager.Setup(x => x.GetData(It.IsAny<DataType>())).Returns(firstnames);
            var service = new FirstLastNameService(_dataManager.Object, _randomNumberGenerator.Object);
            var actual = service.GetLastNames();
            actual.Count.ShouldBeGreaterThanOrEqualTo(2);
        }
    }
}