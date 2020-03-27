using System.Collections.Generic;
using System.Linq;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class FirstLastNameService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IDataManager _dataManager;
        private List<string> _firstNames = new List<string>();
        private List<string> _lastnames = new List<string>();

        public FirstLastNameService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string GetFirstName()
        {
            if (!_firstNames.Any())
            {
                BuildLists();
            }
            return _firstNames[_randomNumberGenerator.GetRandomIntegerBetween(0, _firstNames.Count -1)];
        }
        
        public string GetLastName()
        {
            if (!_lastnames.Any())
            {
                BuildLists();
            }
            return _lastnames[_randomNumberGenerator.GetRandomIntegerBetween(0, _lastnames.Count -1)];
        }
        public List<string> GetFirstNames()
        {
            if (!_firstNames.Any())
            {
                BuildLists();
            }
            return _firstNames;
        }
        
        public List<string> GetLastNames()
        {
            if (!_lastnames.Any())
            {
                BuildLists();
            }
            return _lastnames;
        }

        private void BuildLists()
        {
            var names = _dataManager.GetData(DataType.FirstNameLastName).Split('\n');
            foreach(var name in names)
            {
                if (name.Length > 0)
                {
                    var fullname = name.Split(',');
                    if (fullname.Length > 1)
                    {
                        _firstNames.Add(fullname[0]);
                        _lastnames.Add(fullname[1]);
                    }
                }
            }
        }
    }
}