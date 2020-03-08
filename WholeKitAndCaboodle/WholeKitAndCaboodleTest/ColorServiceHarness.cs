using System.Globalization;
using Moq;
using Shouldly;
using WholeKitAndCaboodle;
using Xunit;

namespace WholeKitAndCaboodleTest
{
    public class ColorServiceHarness
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        private readonly Mock<IDataManager> _dataManager = new Mock<IDataManager>();

        [Fact]
        public void ShouldReturnRGBColorArray()
        {
            var service = new ColorService(_dataManager.Object, _randomNumberGenerator);
            var rgb = service.GetRGBColorArray();
            rgb.Length.ShouldBe(3);
        }

        [Fact]
        public void ShouldReturnHex()
        {
            var service = new ColorService(_dataManager.Object, _randomNumberGenerator);
            var hex = service.GetHexColor();
            hex.ShouldStartWith("#");
            hex.Length.ShouldBe(7);
        }

        [Fact]
        public void ShouldReturnColorName()
        {
            const string colors = "purple\nyellow\norange\n";
            _dataManager.Setup(x => x.GetData(DataType.Color)).Returns(colors);

            var service = new ColorService(_dataManager.Object, _randomNumberGenerator);
            var name = service.GetColorName();
            colors.ShouldContain(name);
            name.Length.ShouldBe(6);
        }
    }
}
