using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class UserProfileService
    {
        private readonly DataManager _dataManager;
        private readonly List<UserProfile> _profiles;
        private readonly Range _profilesRange;
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public UserProfileService()
        {
            _dataManager = new DataManager();
            _profiles = _dataManager.GetProcfiles();
            _profilesRange = new Range(0, _profiles.Count - 1);
            _randomNumberGenerator = new RandomNumberGenerator();

        }
        
        public List<UserProfile> GetUserProfiles(int size)
        {
            var addresses = new List<UserProfile>();
            var profileData = _dataManager.GetProcfiles();
            
            for (var i = 0; i < size; i++)
            {
                var index = _randomNumberGenerator.GetRandomIntegerBetween(_profilesRange.Start, _profilesRange.End);
                addresses.Add(profileData[index]);
            }

            return addresses;
        }
    }
}