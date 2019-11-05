namespace WholeKitAndCaboodle
{
    public class MemoryContext
    {
        private static MemoryContext _context;

        private MemoryContext()
        {
            
        }
        
        public static MemoryContext Context()
        {
            if (_context == null)
            {
                _context = new MemoryContext();
            }

            return _context;
        }

        public string GetDataString()
        {
            return "";
        }
    }
}