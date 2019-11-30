using System;
using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class VehicleDataService
    {
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private List<string> _vin;
        //"VIN",Mileage,Year,"Make","Model",SuggestedWholesale,SuggestedRetail,PremiumFactor,"TrimLevel","Problem"
        private List<VehicleData> _vehicleData = new List<VehicleData>();
        public VehicleDataService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public List<VehicleData> GetVehicleData()
        {
            BuildList();
            return _vehicleData;
        }

        private void BuildList()
        {
            var data = _dataManager.GetData(DataType.Vehicle);
            var rows = data.Split('\n');
            foreach (var c in rows)
            {
                var f = c.Split(',');
                var v = new VehicleData() {
                    Milage = f[1],
                    Year = f[2],
                    Make = f[3],
                    Model = f[4],
                    RetailPrice = f[5]
                    };
                _vehicleData.Add(v);
            }

        }
    }
}
