using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class PhoneNumber
    {
        private readonly PhoneNumberService _service; 
        
        private static PhoneNumber _context;
        private static PhoneNumber Context => _context ?? (_context = new PhoneNumber());

        private PhoneNumber()
        {
            _service = new PhoneNumberService(new DataManager(), new RandomNumberGenerator());
        }
        
        private string GetTenDigitPhoneNumberContext()
        {
            return _service.GetTenDigitPhoneNumber();
        }
        
        public static string GetTenDigitPhoneNumber()
        {
            return Context.GetTenDigitPhoneNumberContext();
        }
        
    }
}