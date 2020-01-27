using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class AddressService
    {
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly string [] _streetNames;

        public AddressService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _streetNames  = dataManager.GetData(DataType.Street).Split('\n');
            _randomNumberGenerator = randomNumberGenerator;
        }
        
 

        public string  GetAddressNumber()
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString();
        }

        public string Street()
        {
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0,  _streetNames.Length -1);
            return _streetNames[index];
        }
    }    
}