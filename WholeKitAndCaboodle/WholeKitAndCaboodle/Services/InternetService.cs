using System;
using System.Collections;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class InternetService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IDataManager _dataManager;
        private readonly PasswordGenerator _passwordGenerator;

        public InternetService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _dataManager = dataManager;
            _passwordGenerator = new PasswordGenerator(_randomNumberGenerator);
        }

        public string GetIPV4()
        {
            var array = new int[]
            {
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255),
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255),
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255)
            };
            return string.Join(".",array);
        }

        public string GetUserName(string separator = "")
        {
            return $"{Name.GetFirstName()[0]}{separator}{Name.GetLastName()}";
        }


        public string GetInvalidEmailAddress()
        {
            return $"{GetUserName()}@example.com";
        }

        public string GetPassword(int length = 8, string casing="both" )
        {
            switch (casing)
            {
                case "both":
                {
                    return _passwordGenerator.GetBothUpperAndLower(length);
                }
                case "lower":
                {
                    return _passwordGenerator.GetLower(length);
                }
                case "upper":
                {
                    return _passwordGenerator.GetUpper(length);
                }
                default:
                {
                    throw new NotImplementedException($"casing: {casing} is supported us both|upper|lower");
                }
            }
        }

        private class PasswordGenerator
        {
            private readonly IRandomNumberGenerator _randomNumberGenerator;
            public PasswordGenerator(IRandomNumberGenerator randomNumberGenerator)
            {
                _randomNumberGenerator = randomNumberGenerator;
            }
            public string GetBothUpperAndLower(int length)
            {
                var pwd = "";
                for (var i = 0; i < length; i++)
                {
                    if (_randomNumberGenerator.GetRandomIntegerBetween(new Range(0, 9)) % 2 == 0)
                    {
                        pwd += _randomNumberGenerator.GetRandomLetterUpper();
                    }
                    else
                    {
                        pwd += _randomNumberGenerator.GetRandomLetterLower();
                    }

                }

                return pwd;
            }

            public string GetUpper(int length)
            {
                var pwd = "";
                for (var i = 0; i < length; i++)
                {
                    pwd += _randomNumberGenerator.GetRandomLetterUpper();
                }
                return pwd;
            }
            
            public string GetLower(int length)
            {
                var pwd = "";
                for (var i = 0; i < length; i++)
                {
                    pwd += _randomNumberGenerator.GetRandomLetterLower();
                }
                return pwd;
            }
        }
    }
}
