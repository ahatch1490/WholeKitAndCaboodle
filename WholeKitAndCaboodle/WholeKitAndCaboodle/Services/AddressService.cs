using System;
using System.Collections.Generic;
using System.Linq;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class AddressService
    {
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private  string [] _streetNames;
        private  string[] _cities;
        private string[] _abbreviatedStates;
        private Dictionary<string,string> _zips;
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
            var zips = GetZips();
            var index = _randomNumberGenerator.GetRandomIntegerBetween(0, _zips.Values.Count-1);
            return FormatZip(_zips.Values.ToArray()[index]);
        }
        public string GetZip(string state)
        {
            var zips = GetZips();
            var zip = zips[state];
            return FormatZip(zip);
        }

        private string FormatZip(string zipTemplate)
        {
            //TODO need to change this to use string formatting
            var value = _randomNumberGenerator.GetRandomIntegerBetween(0, 99).ToString("00");
            return zipTemplate.Replace("##", value);
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

        private Dictionary<string,string> GetZips()
        {
            if (_zips != null) return _zips;
            
            var zipList = _dataManager.GetData(DataType.ZipCode).Split('\n');
            _zips = new Dictionary<string, string>();
            foreach (var zip in zipList)
            {
                var data = zip.Split(',');
                _zips.Add(data[0],data[1]);
            }

            return _zips;
        }
    }    
}