using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public  class Color
    {
        private readonly ColorService _service; 
        
        private static Color _context;
        protected static Color Context => _context ?? (_context = new Color());

        private Color()
        {
            _service = new ColorService(new DataManager(), new RandomNumberGenerator());
        }

        private string GetHexColorContext()
        {
            return _service.GetHexColor();
        }

        public static string GetHexColor()
        {
            return Context.GetHexColorContext();
        }
        
        private string GetColorNameContext()
        {
            return _service.GetColorName();
        }

        public static string  GetColorName()
        {
            return Context.GetColorNameContext();
        }
    }
}