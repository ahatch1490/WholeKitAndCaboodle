using System.Collections.Generic;
using System.Linq;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class EmailService
    {
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private List<string> _emails= new List<string>();
        public EmailService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
            BuildList();
        }

        public string GetEmail()
        {
            var email = _emails[_randomNumberGenerator.GetRandomIntegerBetween(0, _emails.Count)];
            return $"{_randomNumberGenerator.GetRandomIntegerBetween(0, 100)}_{email}";

        }

        public List<string> GetEmails()
        {
            return _emails.Select(x => $"{_randomNumberGenerator.GetRandomIntegerBetween(0,100)}_{x}").ToList();
        }

        private void BuildList()
        {
            var data = _dataManager.GetData(DataType.Email);
            var emailData = data.Split('\n');
            foreach(var email in emailData)
            {
                _emails.Add(email);
            }
            
        }
    }
}
