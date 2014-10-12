using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Easy_Weight.Resources;

using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

using Easy_Weight.Model;

namespace Easy_Weight
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        
        public WeightModel weights { get; set; }
        private async Task InitializeModel(){
            weights = new WeightModel();
            try
            {
                await weights.deserializeJsonAsync();
            }
            catch (FileNotFoundException e)
            {
                //So it's probably really bad form to just throw away an exception, but I don't really need to do anything in this case. Just ignore and move on.
            }
            if (weights.weightList.Count() == 0) 
                weight.Text = "000";
            else
                weight.Text = weights.weightList.Last();
        }
        

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            weights.weightList.Add(new_weight.Text.ToString());
            weight.Text = weights.weightList.Last();
            await weights.writeJsonAsync();
        }

        private async void weight_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeModel();
        }
         
    }
}