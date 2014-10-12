using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Easy_Weight.Model
{
    public class WeightModel
    {
        public List<String> weightList { get; private set; }
        private const string WEIGHTJSONFILE = "weight.json";

        public WeightModel()
        {
            weightList = new List<string>();
        }

        public async Task writeJsonAsync()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<String>));
            using(var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                WEIGHTJSONFILE,
                CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, weightList);
            }
        }

        public async Task deserializeJsonAsync()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<String>));
            using (var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(WEIGHTJSONFILE))
            {
                weightList = (List<String>)jsonSerializer.ReadObject(myStream);
            }
            
        }
    }
}
