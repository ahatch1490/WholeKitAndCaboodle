using System.Collections.Generic;
using System.Xml;

namespace WholeKitAndCaboodle
{
    public class UserProfileService
    {
        private readonly DataManager _dataManager;
        private readonly List<UserProfile> _profiles;
        private readonly Range _profilesRange;
        private readonly RandomNumberGenerator _randomNumberGenerator;
        private List<string> FirstNames;

        public UserProfileService()
        {
            _dataManager = new DataManager();
            _profiles = _dataManager.GetProfiles();
            _profilesRange = new Range(0, _profiles.Count - 1);
            _randomNumberGenerator = new RandomNumberGenerator();

        }
        
        public List<UserProfile> GetUserProfiles(int size)
        {
            var addresses = new List<UserProfile>();
            var profileData = _dataManager.GetProfiles();
            
            for (var i = 0; i < size; i++)
            {
                var index = _randomNumberGenerator.GetRandomIntegerBetween(_profilesRange.Start, _profilesRange.End);
                addresses.Add(profileData[index]);
            }

            return addresses;
        }

//        public string FirstName()
//        {
//            if (FirstNames != null)
//            {
//                var index = _randomNumberGenerator.GetRandomIntegerBetween(_profilesRange.Start, _profilesRange.End);
//                return FirstNames[index];
//            }
//        }

//        public string LastName()
//        {
//            
//        }
//
//        public string Username()
//        {
//            
//        }
    }
}