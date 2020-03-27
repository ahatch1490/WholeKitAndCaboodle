using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class Name
    {
        private readonly FirstLastNameService _service; 
        
        private static Name _context;
        private static Name Context => _context ?? (_context = new Name());

        private Name()
        {
            _service = new FirstLastNameService(new DataManager(), new RandomNumberGenerator());
        }

        private string GetFirstNameContext()
        {
            return _service.GetFirstName();
        }
        
        private string GetLastNameContext()
        {
            return _service.GetLastName();
        }


        public static string GetLastName()
        {
            return Context.GetLastNameContext();
        }
        
        public static string GetFirstName()
        {
            return Context.GetFirstNameContext();
        }
        
    }
}