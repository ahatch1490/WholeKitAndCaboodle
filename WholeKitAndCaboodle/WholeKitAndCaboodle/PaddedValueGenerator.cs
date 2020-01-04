namespace WholeKitAndCaboodle
{
    public class PaddedValueGenerator
    {
        private IRandomNumberGenerator _randomNumberGenerator;

        public PaddedValueGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string PadValue(in int length, int value)
        {
            return "111111";
        }
    }
}