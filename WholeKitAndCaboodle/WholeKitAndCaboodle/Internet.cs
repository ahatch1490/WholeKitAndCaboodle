using System.Net.NetworkInformation;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class Internet
    {
        private readonly InternetService _service; 
        
        private static Internet _context;
        private static Internet Context => _context ?? (_context = new Internet());

        private Internet()
        {
            _service = new InternetService(new DataManager(), new RandomNumberGenerator());
        }

        private string GetIPV4Context()
        {
            return _service.GetIPV4();
        }
        
        private static string GetIPV4()
        {
            return Context.GetIPV4Context();
        }

        private string GetUsernameContext()
        {
            return _service.GetUserName();
        }

        public static string GetUsername()
        {
            return Context.GetUsernameContext();
        }
        
        private string GetPasswordContext(int length = 8, string casing = "both")
        {
            return _service.GetPassword(length, casing);
        }

        public static string GetPassword(int length =8)
        {
            return Context.GetPasswordContext(length);
        }
        public static string GetPasswordUpper(int length =8)
        {
            return Context.GetPasswordContext(length,"upper");
        }
        public static string GetPasswordLower(int length =8)
        {
            return Context.GetPasswordContext(length,"lower");
        }
        
        private string GetEmailInvalidContext()
        {
            return _service.GetInvalidEmailAddress();
        }

        public static string GetEmailInvalid()
        {
            return Context.GetEmailInvalidContext();
        }
    }
}