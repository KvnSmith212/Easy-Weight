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
using System.Windows.Media;

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
        }
        

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weights.weightList.Add(new_weight.Text.ToString());
            }
            catch (System.FormatException f)
            {
                //weights.weightList.Add(weights.weightList.Last());
            }
            Determine_Color();
            //weight.Text = weights.weightList.Last();
            await weights.writeJsonAsync();
        }

        private async void weight_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeModel();
            if (weights.weightList.Count() == 0)
                weights.weightList.Add("000");
            else
            {
                if (weights.weightList.Count() > 1)
                {
                    Determine_Color();
                }
       
            }
            weight.Text = weights.weightList.Last();
        }

        private void Determine_Color()
        {
            int currentI = Convert.ToInt16(weights.weightList.Last());
            int lastI = Convert.ToInt16(weights.weightList[weights.weightList.Count() - 2]);
            int goalI = Convert.ToInt16(weights.weightList[0]);

            //TODO: Figure out how to get the predefined brushes
            if (currentI > goalI - 10 && currentI < goalI + 10)
            {
                weight.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            }
            else if (Math.Abs(currentI - goalI) < Math.Abs(lastI - goalI))
            {
                weight.Foreground = new SolidColorBrush(Color.FromArgb(255, 140, 191, 35));
            }
            else
            {
                weight.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            weights.weightList[0] = new_goal.Text.ToString();
            Determine_Color();
            await weights.writeJsonAsync();
        }
    }
}