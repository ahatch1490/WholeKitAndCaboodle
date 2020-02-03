using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WholeKitAndCaboodle
{
    public class AddressService
    {
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private  string [] _streetNames;
        private  string[] _cities;
        private string[] _abbreviatedStates;

        public AddressService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
        }
        
 

        public string  GetAddressNumber()
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString();
        }

        public string Street()
        {
            if (_streetNames == null)
            {
                _streetNames  = _dataManager.GetData(DataType.Street).Split('\n');
            }
            
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0,  _streetNames.Length -1);
            return _streetNames[index];
        }

        public string GetZip()
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString();
        }

        public string GetCity()
        {
            if (_cities == null)
            {
                _cities = _dataManager.GetData(DataType.City).Split('\n');
            }
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0,  _cities.Length -1);
            return _cities[index];
        }

        public string GetState()
        {
            throw new NotImplementedException();
        }

        public string GetStateAbbreviation()
        {
            if (_abbreviatedStates == null)
            {
                _abbreviatedStates = _dataManager.GetData(DataType.AbbStates).Split('\n');
            }
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0,  _cities.Length -1);
            return _cities[index];
        }
    }    
}