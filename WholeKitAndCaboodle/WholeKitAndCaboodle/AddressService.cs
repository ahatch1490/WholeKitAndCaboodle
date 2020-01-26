using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class AddressService
    {
        private readonly IDataManager _dataManager;
        private readonly List<AddressUS> _addressesUs;
        private readonly Range _USAddressRange;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly List<string> _streetNames;

        public AddressService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _streetNames.AddRange(dataManager.GetData(DataType.Street).Split('\n'));
            _USAddressRange = new Range(0, _addressesUs.Count - 1);
            _randomNumberGenerator = randomNumberGenerator;
        }
        
 

        public string  GetAddressNumber()
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString();
        }

        public string Street()
        {
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0, 1345);
            return "";
        }
    }    
}