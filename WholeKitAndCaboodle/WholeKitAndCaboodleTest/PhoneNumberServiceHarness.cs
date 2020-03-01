using Moq;
using WholeKitAndCaboodle;
using Xunit;
using Shouldly;

namespace WholeKitAndCaboodleTest
{
    public class PhoneNumberServiceHarness
    {
        private Mock<IRandomNumberGenerator> _mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        private Mock<IDataManager> _moqDatamanager = new Mock<IDataManager>();
        [Fact]
        public void ShouldReturnUSPhoneNumber()
        {
            _moqDatamanager.Setup(x =>x.GetData(DataType.AreaCode) ).Returns("123");
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(100, 999)).Returns(123);
            _mockRandomNumberGenerator.Setup(x => x.GetRandomIntegerBetween(0, 9999)).Returns(1111);
            var service = new PhoneNumberService(_moqDatamanager.Object,_mockRandomNumberGenerator.Object);
            var expected = "123-123-1111";
            var actual = service.GetUSPhoneNumber();
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
            var actual = service.GetUSPhoneNumber();
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
    }
}