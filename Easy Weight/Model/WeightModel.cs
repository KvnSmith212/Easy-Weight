using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
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

        /// <summary>
        ///     Saves the list of weight entries as a json file in the applications local folder.
        /// </summary>
        /// <returns></returns>
        public async Task writeJsonAsync()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<String>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                WEIGHTJSONFILE,
                CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, weightList);
            }
        }

        /// <summary>
        ///     Retrieves the serialized weight list from the json file.
        /// </summary>
        /// <returns></returns>
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
