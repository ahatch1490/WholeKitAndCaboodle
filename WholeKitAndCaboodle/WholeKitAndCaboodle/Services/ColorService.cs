using System;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class ColorService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IDataManager _dataManager;
        private readonly Random _random;
        private string[] _colors;
        public ColorService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _random = new Random();
            _randomNumberGenerator = randomNumberGenerator;
            _dataManager = dataManager;
        }
        
        public int GetRGBColorPart()
        {
            return (_randomNumberGenerator.GetRandomIntegerBetween(0, 255));
        }

        public int [] GetRGBColorArray()
        {
            return  new int[] {GetRGBColorPart(), GetRGBColorPart(), GetRGBColorPart()};
        }

        public string GetHexColor()
        { 
            return $"#{_random.Next(0x1000000):X6}";
        }

        public string GetColorName()
        {
            if (_colors is null)
            {
                var data = _dataManager.GetData(DataType.Color);
                _colors = data.Split('\n');
            }
            return _colors[_randomNumberGenerator.GetRandomIntegerBetween(0,_colors.Length -1)];
        }
    }
}