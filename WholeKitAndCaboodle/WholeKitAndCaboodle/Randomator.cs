using System;
using System.Collections.Generic;
using System.Linq;

namespace WholeKitAndCaboodle
{
    public class Randomator
    {
        private readonly AddressService _addressService;
        private readonly RandomNumberGenerator _randomNumberGenerator;
        public Randomator()
        {
           _addressService = new AddressService();
           _randomNumberGenerator = new RandomNumberGenerator();
        }
        public int GetRandomIntegerBetween(Range range)
        {
            return GetRandomIntegerBetween(range.Start, range.End);
        }
        
        public List<int> GetListOfNumbers(int size, Range range)
        {
           return _randomNumberGenerator.GetListOfNumbers(size, range);
        }

        public int GetRandomIntegerBetween(int start, int end)
        {
            return _randomNumberGenerator.GetRandomIntegerBetween(start, end);
        }

        public List<AddressUS> GetUsAddresses(int size)
        {
            return _addressService.GetUsAddresses(size);
        }

        public AddressUS GetUsAddress()
        {
            return _addressService.GetUsAddresses(1).First();
        }
    }
}