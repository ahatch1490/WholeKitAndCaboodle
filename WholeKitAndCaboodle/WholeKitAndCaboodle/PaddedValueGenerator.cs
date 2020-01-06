namespace WholeKitAndCaboodle
{
    public class PaddedValueGenerator
    {
        private IRandomNumberGenerator _randomNumberGenerator;

        public PaddedValueGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string PadValue(int length, int value)
        {
            if (value < 0)
            {
                return string.Empty;
            }
            
            var valueLength = value.ToString().Length;
            var returnVal = value.ToString();
            if (valueLength == length)
            {
                return value.ToString();
            }
            if (valueLength < length)
            {
                var padding =  length - valueLength;
                
                for(var i = 0; i < padding; i++)
                {
                    returnVal = "0" + returnVal;
                }
            }
            return returnVal;
        }
    }
}