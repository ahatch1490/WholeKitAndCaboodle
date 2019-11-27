using System;
using System.Collections.Generic;
using System.Linq;

namespace WholeKitAndCaboodle
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
        }

        public List<string> GetEmails()
        {
            if(!_emails.Any())
            {
                BuildList();
            }
            return _emails;
            
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
