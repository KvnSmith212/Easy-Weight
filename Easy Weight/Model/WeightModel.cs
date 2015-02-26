using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Syncfusion.UI.Xaml.Charts;

namespace Easy_Weight.Model
{
    public class WeightEntry
    {
        public int weight { get; set;}
        public string entryNum { get; set; }
    }

    public class WeightModel
    {
        public ObservableCollection<WeightEntry> weightList { get; private set; }
        private const string WEIGHTJSONFILE = "weight.json";

        public WeightModel()
        {
            weightList = new ObservableCollection<WeightEntry>();
        }

        public void clear()
        {
            weightList.Clear();
        }

        /// <summary>
        ///     Saves the list of weight entries as a json file in the applications local folder.
        /// </summary>
        /// <returns></returns>
        public async Task writeJsonAsync()
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<WeightEntry>));
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
            Debug.WriteLine("USER DEBUG: deserializing json");

            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<WeightEntry>));
            using (var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(WEIGHTJSONFILE))
            {
                weightList = (ObservableCollection<WeightEntry>)jsonSerializer.ReadObject(myStream);
            }

            Debug.WriteLine("USER DEBUG: deserialization successfull");
        }
    }
}
