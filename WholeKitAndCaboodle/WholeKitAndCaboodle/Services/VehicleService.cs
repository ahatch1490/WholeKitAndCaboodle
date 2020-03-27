using System.Collections.Generic;
using WholeKitAndCaboodle.Common;
using WholeKitAndCaboodle.Models;

namespace WholeKitAndCaboodle.Services
{
    public class VehicleDataService
    {
        private const int MAX_VALUE = 99999;
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IPaddingValueGenerator _paddingValueGenerator;
        //"VIN",Mileage,Year,"Make","Model",SuggestedWholesale,SuggestedRetail,PremiumFactor,"TrimLevel","Problem"
        private List<VehicleData> _vehicleData = new List<VehicleData>();
        public VehicleDataService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator, IPaddingValueGenerator paddingValueGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
            _paddingValueGenerator = paddingValueGenerator;
            BuildList();
        }

        /// <summary>
        /// Returns the complete list of vehicles
        /// </summary>
        /// <returns></returns>
        public VehicleData  GetVehicleData()
        {
            var index = _randomNumberGenerator.GetRandomIntegerBetween(0, _vehicleData.Count -1);
            var v = _vehicleData[index];
            v.Vin = $"{v.Vin.Substring(0,v.Vin.Length - 6 )}{RandomProductionNumber()}";
            return v;
        }
        /// <summary>
        /// Returns a specified count of random vehicles.
        /// </summary>
        /// <param name="count">number of vehicles to return</param>
        /// <returns></returns>
        public List<VehicleData> GetListOfVehicleData(int count)
        {
            var r = new Range(0, _vehicleData.Count - 1);
            var returnList = new List<VehicleData>();
            var indexes = _randomNumberGenerator.GetListOfNumbers(count, r);

            foreach(var index in indexes)
            {
                returnList.Add(_vehicleData[index]);
            }
            return returnList;
        }

        private void BuildList()
        {
            var data = _dataManager.GetData(DataType.Vehicle);
            var rows = data.Split('\n');
            var uniqueIds = new List<string>();
            foreach (var c in rows)
            {
                if (c.Length == 0)
                {
                    continue;
                }
                
                var f = c.Split(',');

                var v = new VehicleData() {
                    Vin = f[0],
                    Milage = f[1],
                    Year = f[2],
                    Make = f[3],
                    Model = f[4],
                    RetailPrice = f[5]
                    };
                _vehicleData.Add(v);
            }

        }

        private string RandomProductionNumber()
        {
            var id = _randomNumberGenerator.GetRandomIntegerBetween(1, MAX_VALUE);
            var alpha = _randomNumberGenerator.GetRandomLetterUpper();
            var strId = string.Empty;
            strId = $"{alpha}{_paddingValueGenerator.PadLeftValue(4, id)}";
            return strId;
        }
    }
}
