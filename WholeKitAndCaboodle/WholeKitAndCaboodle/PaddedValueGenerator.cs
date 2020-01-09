namespace WholeKitAndCaboodle
{
    public class PaddedValueGenerator: IPaddingValueGenerator
    {
        private IRandomNumberGenerator _randomNumberGenerator;

        public PaddedValueGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string PadLeftValue(int length, int value)
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