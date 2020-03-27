using System;
using System.Collections.Generic;
using Moq;
using WholeKitAndCaboodle;
using Xunit;
using Shouldly;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodleTest
{
    public class EmailTestServiceHarness
    {
        private Mock<IDataManager> _dataManager = new Mock<IDataManager>();
        private Mock<IRandomNumberGenerator> _randomNumberGenerator = new Mock<IRandomNumberGenerator>();
        public EmailTestServiceHarness()
        {
        }

        [Fact]
        public void ShouldReturnAListOfEmails()
        {
            var data = $"foobar@example.com{Environment.NewLine}goofoo@example.foo";
            _dataManager.Setup(x => x.GetData(DataType.Email)).Returns(data);
            var service = new EmailService(_dataManager.Object, _randomNumberGenerator.Object);
            List<string> emails = service.GetEmails();
            emails.ShouldNotBeEmpty();
        }

        [Fact]
        public void ShouldReturnEmail()
        {
            var service = new EmailService(new DataManager(),new RandomNumberGenerator());
            var actual = service.GetEmail(); 
            actual.ShouldNotBeNull();
        }
    }
}
