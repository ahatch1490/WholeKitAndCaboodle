using System;
using System.Collections.Generic;
using System.Text;

namespace WholeKitAndCaboodle
{
    public class VehicleDataService
    {
        private const int MAX_VALUE = 99999;
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
        protected VehicleData  GetVehicleData()
        {
            var index = _randomNumberGenerator.GetRandomIntegerBetween(0, _vehicleData.Count);
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
            if(id > MAX_VALUE)
            {
                strId = $"{alpha}{id.ToString()}";
            }

            if(id < 9999)
            {
                if (id < 1000)
                {
                    if (id < 100)
                    {
                        if (id < 10)
                        {
                            strId = $"{alpha}0000{id}";
                        }
                        else
                        {
                            strId = $"{alpha}00{id}";
                        }
                    }
                    else
                    {
                        strId = $"{alpha}0{id}";
                    }
                }
            }
            else
            {
                strId = $"{alpha}{id}";
            }
           
            return strId;
        }
    }
}
