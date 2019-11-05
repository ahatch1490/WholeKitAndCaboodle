using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Newtonsoft.Json;
namespace WholeKitAndCaboodle
{
    public class DataManager
    {
        private static List<AddressUS> USAddresses { get; set; }
        private static MemoryStream inMemoryCopy = new MemoryStream();
        public List<AddressUS> GetAddressesDataUS()
        {
            var address = new List<AddressUS>();
            var assembly = typeof(WholeKitAndCaboodle.DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.us_address.json");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate us_address")))
            {
                var json = reader.ReadToEnd();
                address = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AddressUS>>(json);
            }

            return address;
        }
        
        public List<UserProfile> GetProcfiles()
        {
            var profiles = new List<UserProfile>();
            var assembly = typeof(WholeKitAndCaboodle.DataManager).GetTypeInfo().Assembly;
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
            var assembly = typeof(WholeKitAndCaboodle.DataManager).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("WholeKitAndCaboodle.data.basedata.json");
            using (var reader =
                new System.IO.StreamReader(resource ?? throw new NullReferenceException("unable to locate profile")))
            {
                
                resource.CopyTo(inMemoryCopy);

            }

            return profiles;
        }
    }
}