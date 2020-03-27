using Moq;
using WholeKitAndCaboodle;
using Xunit;
using Shouldly;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodleTest
{
    public class PhoneNumberServiceHarness
    {
        private Mock<IRandomNumberGenerator> _mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        private Mock<IDataManager> _moqDatamanager = new Mock<IDataManager>();
        [Fact]
        public void ShouldDashedReturnUSPhoneNumber()
        {
            _moqDatamanager.Setup(x =>x.GetData(DataType.AreaCode) ).Returns("123");
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(100, 999)).Returns(123);
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(0, 9999)).Returns(1111);
            var service = new PhoneNumberService(_moqDatamanager.Object,_mockRandomNumberGenerator.Object);
            var expected = "123-123-1111";
            var actual = service.GetDashedUSPhoneNumber();
            actual.ShouldMatch(expected);
        }
        [Fact]
        public void ShouldJustDashedReturnPhoneNumber()
        {
            var service = new PhoneNumberService(new DataManager(), new RandomNumberGenerator());
            var actual = service.GetDashedUSPhoneNumber();
            actual.Length.ShouldBe(12);
        }

        [Fact]
        public void ShouldReturnA10DigitPhoneNumber()
        {
            _moqDatamanager.Setup(x =>x.GetData(DataType.AreaCode) ).Returns("206");
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(100, 999)).Returns(222);
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(0, 9999)).Returns(2);
            var service = new PhoneNumberService(_moqDatamanager.Object,_mockRandomNumberGenerator.Object);
            const string expected = "2062220002";
            var actual = service.GetTenDigitPhoneNumber();
            actual.ShouldMatch(expected);
        }
        
        [Fact]
        public void ShouldReturnUSPhoneNumberPaddedWithZeros()
        {
            _moqDatamanager.Setup(x =>x.GetData(DataType.AreaCode) ).Returns("123");
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(100, 999)).Returns(123);
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(0, 9999)).Returns(1);
            var service = new PhoneNumberService(_moqDatamanager.Object,_mockRandomNumberGenerator.Object);
            const string expected = "123-123-0001";
            var actual = service.GetDashedUSPhoneNumber();
            actual.ShouldMatch(expected);
        }

        [Fact]
        public void ShouldReturnAreaCode()
        {
            _moqDatamanager.Setup(x =>x.GetData(DataType.AreaCode) ).Returns("222");
            var service = new PhoneNumberService(_moqDatamanager.Object,_mockRandomNumberGenerator.Object);
            var areaCode =  service.GetAreaCode();
            areaCode.ShouldBe("222");
        }

        [Fact]
        public void ShouldBeAbleToCallFromFacade()
        {
            var phone = PhoneNumber.GetTenDigitPhoneNumber();
            phone.Length.ShouldBe(10);
        }
        
    }
}