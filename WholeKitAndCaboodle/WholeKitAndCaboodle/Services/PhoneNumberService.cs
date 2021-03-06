using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class PhoneNumberService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private  string[] _areaCodes;
        private readonly IDataManager _dataManager;
        
        public string GetAreaCode()
        {
            if (_areaCodes == null)
            {
                _areaCodes  = _dataManager.GetData(DataType.AreaCode).Split('\n');
            }
            
            var  index = _randomNumberGenerator.GetRandomIntegerBetween(0,  _areaCodes.Length -1);
            return _areaCodes[index];
        }
            
          
        public PhoneNumberService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
        }
        
        public string GetTenDigitPhoneNumber()
        {
            var areaCode = GetAreaCode();
            var prefix = _randomNumberGenerator.GetRandomIntegerBetween(100, 999);
            var postfix =  _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString("0000");
            return $"{areaCode}{prefix}{postfix}";
        }
        public string GetDashedUSPhoneNumber()
        {
            var areaCode = GetAreaCode();
            var prefix = _randomNumberGenerator.GetRandomIntegerBetween(100, 999);
            var postfix =  _randomNumberGenerator.GetRandomIntegerBetween(0, 9999).ToString("0000");
            return $"{areaCode}-{prefix}-{postfix}";
        }
        
    }
}