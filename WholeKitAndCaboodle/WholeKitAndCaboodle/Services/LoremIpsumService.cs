using System.Text;
using WholeKitAndCaboodle.Common;

namespace WholeKitAndCaboodle.Services
{
    public class LoremIpsumService
    {
        private string[] _paragraphs;
        private IDataManager _dataManager;
        private IRandomNumberGenerator _randomNumberGenerator;

        public LoremIpsumService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
            _paragraphs = _dataManager.GetData(DataType.LoremIpsum).Replace("\"","" ).Split('\n');
        }
        public string GetParagraph()
        {
           return _paragraphs[_randomNumberGenerator.GetRandomIntegerBetween(0, _paragraphs.Length - 1)];
        }
    }
}