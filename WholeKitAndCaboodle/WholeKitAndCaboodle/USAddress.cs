using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class USAddress
    {
        private readonly AddressService _service; 
        
        private static USAddress _context;
        private static USAddress Context => _context ?? (_context = new USAddress());

        private USAddress()
        {
            _service = new AddressService(new DataManager(), new RandomNumberGenerator());
        }

        private string GetStreetContext()
        {
            return _service.Street();
        }

        public static string GetStreet()
        {
            return Context.GetStreetContext();
        }

        private string GetZipCodeContext()
        {
            return _service.GetZip();
        }

        public static string GetZipCode()
        {
            return Context.GetZipCodeContext();
        }
        
        private string GetCityContext()
        {
            return _service.GetCity();
        }
        
        private string GetStateContext()
        {
            return _service.GetState();
        }
        
        private string GetStateAbbreviationContext()
        {
            return _service.GetStateAbbreviation();
        }
        
        private string GetAddressNumberContext()
        {
            return _service.GetAddressNumber();
        }
        
        public static string GetCityCode()
        {
            return Context.GetCityContext();
        }
        
        public static string GetStateCode()
        {
            return Context.GetStateContext();
        }
        
        public static string GetStateAbbreviation()
        {
            return Context.GetStateAbbreviationContext();
        }
        
    }
}