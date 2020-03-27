using System;
using System.Collections.Generic;
using System.Linq;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Models;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class Randomator
    {
        private readonly AddressService _addressService;
        private readonly UserProfileService _userProfileService;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IDataManager _dataManager;
        public Randomator()
        {
            _dataManager = new DataManager();
           _addressService = new AddressService(_dataManager, _randomNumberGenerator);
           _userProfileService = new UserProfileService();
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

        public UserProfile GetUserProfile()
        {
            return _userProfileService.GetUserProfiles(1).First();
        }

        public List<UserProfile> GetUserProfiles(int size)
        {
            return _userProfileService.GetUserProfiles(size);
        }
    }
}