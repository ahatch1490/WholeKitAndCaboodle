using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using WholeKitAndCaboodle.Models;
[assembly: InternalsVisibleTo("WholeKitAndCaboodleTest")]
namespace WholeKitAndCaboodle.Common
{
    public class DataManager: IDisposable, IDataManager
    {
        private  List<AddressUS> USAddresses { get; set; }
        private  MemoryStream inMemoryCopy = new MemoryStream();

        public  DataManager()
        {
            BuildMemoryStream();
        }

        public string GetData(DataType dataType)
        {
            return GetDataString(dataType);
        }

        public List<AddressUS> GetAddressesDataUS()
        {
            var address = new List<AddressUS>();
            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.us_address.json");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate us_address")))
            {
                var json = reader.ReadToEnd();
                address = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AddressUS>>(json);
            }

            return address;
        }

        public string GetRawData()
        {
            inMemoryCopy.Position = 0;
            return new StreamReader(inMemoryCopy).ReadToEnd();
          
        }
        
        public List<UserProfile> GetProfiles()
        {
            var profiles = new List<UserProfile>();
            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.profile.json");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate profile")))
            {
                var json = reader.ReadToEnd();
                profiles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserProfile>>(json);
            }

            return profiles;
        }
        
        private List<UserProfile> GetData()
        {
            var profiles = new List<UserProfile>();
            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.basedata.json");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate profile")))
            {                
                resource.CopyTo(inMemoryCopy);
            }

            return profiles;
        }
        
        public List<string> GetDataAttribute(string attribute)
        {
            var json = GetRawData();
            JObject rss = JObject.Parse(json);
            return ((JArray) rss[attribute]).Select(x => (string) x).ToList();

        }
        public void Dispose()
        {
            inMemoryCopy.Close();
            inMemoryCopy = null;
        }

        private void BuildMemoryStream()
        {
            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            using (Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.us_address.json"))
            {
                using (var reader =
                    new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate data")))
                {                
                    resource.CopyTo(inMemoryCopy);
                    inMemoryCopy.Position = 0;
                }
            }
        }

        private string GetDataString(DataType dataType)
        {
            var data = string.Empty;
            var assembly = typeof(DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream($"WholeKitAndCaboodle.data.{dataType.ToString()}.csv");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException($"unable to locate '{dataType.ToString()}'")))
            {
                data = reader.ReadToEnd();
            }
            
            return data;
        }

    }
}