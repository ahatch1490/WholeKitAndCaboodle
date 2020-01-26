using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class AddressService
    {
        private readonly DataManager _dataManager;
        private readonly List<AddressUS> _addressesUs;
        private readonly Range _USAddressRange;
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public AddressService()
        {
            _dataManager = new DataManager();
            _addressesUs = _dataManager.GetAddressesDataUS();
            _USAddressRange = new Range(0, _addressesUs.Count - 1);
            _randomNumberGenerator = new RandomNumberGenerator();

        }
        
        public List<AddressUS> GetUsAddresses(int size)
        {
            var addresses = new List<AddressUS>();
            var addressesData = _dataManager.GetAddressesDataUS();
            
            for (var i = 0; i < size; i++)
            {
                var index = _randomNumberGenerator.GetRandomIntegerBetween(_USAddressRange.Start, _USAddressRange.End);
                addresses.Add(addressesData[index]);
            }

            return addresses;
        }

        public string  GetAddressNumber()
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString();
        }

        public string Street()
        {
            
        }
    }
}