using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace WholeKitAndCaboodle
{
    public class PhoneNumberService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public PhoneNumberService(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }
        public string GetUSPhoneNumber()
        {
            var areaCode = _randomNumberGenerator.GetRandomIntegerBetween(100, 999);
            var prefix = _randomNumberGenerator.GetRandomIntegerBetween(100, 999);
            var postfix =  _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString("0000");
            return $"{areaCode}-{prefix}-{postfix}";
        }
        
    }
}