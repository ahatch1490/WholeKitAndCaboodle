using System;
using System.Linq;
using System.Threading.Channels;
using Moq;
using Shouldly;
using WholeKitAndCaboodle;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;
using Xunit;
using Xunit.Sdk;

namespace WholeKitAndCaboodleTest
{
    public class InternetServiceTest
    {
        private Mock<IDataManager> _dataManager = new Mock<IDataManager>();
        private Mock<IRandomNumberGenerator> _mockRandomGenerator = new Mock<IRandomNumberGenerator>();
        private IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        
        [Fact]
        public void ShouldReturnVpIPAddress()
        {
            _mockRandomGenerator
                .Setup(x => x.GetRandomIntegerBetween(0, 255))
                .Returns(255);
            var service = new InternetService(_dataManager.Object, _mockRandomGenerator.Object);
            var ip = service.GetIPV4();
            ip.ShouldBe("255.255.255");
        }

        [Fact]
        public void ShouldReturnAUsername()
        {
            var service = new InternetService(new DataManager(),  new RandomNumberGenerator());

            service.GetUserName().Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void ShouldReturnStringIncludingSeparators()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());
            service.GetUserName("--").ShouldContain("--");
        }

        [Fact]
        public void ShouldReturnGetInvalidExampleEmailAddress()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());
            service.GetInvalidEmailAddress().ShouldContain("@example.com");
        }
        [Fact]
        public void ShouldReturnRandomPassword()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());
            service.GetPassword().Length.ShouldBeGreaterThan(0);
        }
        [Fact]
        public void ShouldHaveDefaultLengthOfEight()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());
            service.GetPassword().Length.ShouldBe(8);
        }
        
        [Fact]
        public void ShouldBeAbleToSetLength()
        {
            const int expected = 9;
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());
            service.GetPassword(expected).Length.ShouldBe(expected);
        }
        
        [Fact]
        public void ShouldBeAbleToMakeUpper()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());  
            var actual = service.GetPassword(casing: "upper");
            var expected = actual.ToUpper();
            actual.ShouldMatch(expected);
        }
        
        [Fact]
        public void ShouldBeAbleToMakeLower()
        {
            var service = new InternetService(new DataManager(), new RandomNumberGenerator());  
            var actual = service.GetPassword(casing: "lower");
            var expected = actual.ToLower();
            actual.ShouldMatch(expected);
        }


    }
}