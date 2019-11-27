using System;
using System.Collections.Generic;
using System.Linq;

namespace WholeKitAndCaboodle
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
                var fullname = name.Split(',');
                _firstNames.Add(fullname[0]);
                _lastnames.Add(fullname[1]);
            }
        }
    }
}