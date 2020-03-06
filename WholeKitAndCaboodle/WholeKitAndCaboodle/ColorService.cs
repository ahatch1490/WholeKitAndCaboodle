using System;

namespace WholeKitAndCaboodle
{
    public class ColorService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly Random _random;
        public ColorService(IRandomNumberGenerator randomNumberGenerator)
        {
            _random = new Random();
            _randomNumberGenerator = randomNumberGenerator;
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
    }
}