using System.Linq;
using WholeKitAndCaboodle;

namespace WholeKitAndCaboodle
{
    public class InternetService
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IDataManager _dataManager;

        public InternetService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _dataManager = dataManager;
        }

        public string GetIPV4()
        {
            var array = new int[]
            {
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255),
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255),
                _randomNumberGenerator.GetRandomIntegerBetween(0, 255)
            };
            return string.Join(".",array);
        }
    }
}
