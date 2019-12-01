using System;
using System.Collections.Generic;

namespace WholeKitAndCaboodle
{
    public class VehicleDataService
    {
        private const int MAX_VALUE = 999999;
        private readonly IDataManager _dataManager;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        //"VIN",Mileage,Year,"Make","Model",SuggestedWholesale,SuggestedRetail,PremiumFactor,"TrimLevel","Problem"
        private List<VehicleData> _vehicleData = new List<VehicleData>();
        public VehicleDataService(IDataManager dataManager, IRandomNumberGenerator randomNumberGenerator)
        {
            _dataManager = dataManager;
            _randomNumberGenerator = randomNumberGenerator;
            BuildList();
        }

        /// <summary>
        /// Returns the complete list of vehicles
        /// </summary>
        /// <returns></returns>
        public List<VehicleData> GetVehicleData()
        {
            return _vehicleData;
        }
        /// <summary>
        /// Returns a specified count of random vehicles.
        /// </summary>
        /// <param name="count">number of vehicles to return</param>
        /// <returns></returns>
        public List<VehicleData> GetVehicleData(int count)
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
                var f = c.Split(',');
                var baseVin = f[0].Substring(0, 10);
                var id = RandomVinId();
                var vin = baseVin + id;
                var count = 0;
                while(uniqueIds.Contains(vin) && count < MAX_VALUE)
                {
                    id = RandomVinId();
                    vin = baseVin + id;
                    count++;
                    if (count < MAX_VALUE)
                    {
                        throw new MaxVehicleRangeException($"Max unique count reached {MAX_VALUE}.");
                    }
                }
                uniqueIds.Add(vin);


                var v = new VehicleData() {
                    Vin = vin,
                    Milage = f[1],
                    Year = f[2],
                    Make = f[3],
                    Model = f[4],
                    RetailPrice = f[5]
                    };
                _vehicleData.Add(v);
            }

        }

        private string RandomVinId()
        {
            var id = _randomNumberGenerator.GetRandomIntegerBetween(1, MAX_VALUE);
            var strId = string.Empty;
            if(id > 99999)
            {
                strId = id.ToString();
            }

            if(id < 99999)
            {
                if (id < 1000)
                {
                    if (id < 100)
                    {
                        if (id < 10)
                        {
                            strId = $"00000{id}";
                        }
                        else
                        {
                            strId = $"000{id}";
                        }
                    }
                    else
                    {
                        strId = $"00{id}";
                    }
                }
            }
            else
            {
                strId = $"0{id}";
            }
           
            return strId;
        }
    }
}
