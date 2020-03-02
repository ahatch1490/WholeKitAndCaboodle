using System;

namespace WholeKitAndCaboodle
{
    public class ColorService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public ColorService(IRandomNumberGenerator randomNumberGenerator)
        {
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
    }
}