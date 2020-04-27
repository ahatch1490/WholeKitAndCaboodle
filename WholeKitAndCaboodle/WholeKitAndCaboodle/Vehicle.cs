using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Models;
using WholeKitAndCaboodle.Services;

namespace WholeKitAndCaboodle
{
    public class Vehicle
    {
        private readonly VehicleDataService _service; 
        
        private static Vehicle _context;
        private static Vehicle Context => _context ?? (_context = new Vehicle());

        private Vehicle()
        {
            _service = new VehicleDataService(new DataManager(), new RandomNumberGenerator(), new PaddedValueGenerator(new RandomNumberGenerator()));
        }

        private VehicleData GetVehicleDataContext()
        {
            return _service.GetVehicleData();
        }

        public static VehicleData GetVehicleData()
        {
            return Context.GetVehicleDataContext();
        }
    }
}