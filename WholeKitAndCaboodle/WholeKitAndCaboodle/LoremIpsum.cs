using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class LoremIpsum
    {
        private readonly LoremIpsumService _service; 
        
        private static LoremIpsum _context;
        private static LoremIpsum Context => _context ?? (_context = new LoremIpsum());

        private LoremIpsum()
        {
            _service = new LoremIpsumService(new DataManager(), new RandomNumberGenerator());
        }
        
        private string GetParagraphContext()
        {
            return _service.GetParagraph();
        }
        
        public static string GetParagraph()
        {
            return Context.GetParagraphContext();
        }
    }
}