using Easy_Weight.Model;
using Microsoft.Phone.Controls;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Easy_Weight
{
    public partial class MainPage : PhoneApplicationPage
    {
        public WeightModel weights { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        ///     Used to set the weight on the main page at startup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///     Calls the deserialize method to initialize the weightlist.
        /// </summary>
        /// <returns></returns>
        private async Task InitializeModel()
        {
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

        /// <summary>
        ///     Tries to add a new weight entry and update the weight on the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weights.weightList.Add(new_weight.Text.ToString());
                Determine_Color();
            }
            catch (System.FormatException f)
            {
                if (weights.weightList.Count() > 1)
                {
                    weights.weightList.RemoveAt(weights.weightList.Count() - 1);
                }
            }
            weight.Text = weights.weightList.Last();
            await weights.writeJsonAsync();
        }

        /// <summary>
        ///     Tries to update the goal weight, which is sotred at index 0 of the weight list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string currGoal = weights.weightList[0];
            try
            {
                weights.weightList[0] = new_goal.Text.ToString();
                Determine_Color();
            }
            catch (System.FormatException f)
            {
                weights.weightList[0] = currGoal;
            }
            catch (System.ArgumentOutOfRangeException f)
            {
                weights.weightList[0] = new_goal.Text.ToString();
            }
            await weights.writeJsonAsync();
        }

        /// <summary>
        ///     Determines the color of the weight on the main page, based on whether the new entry is closer or farther away from the goal weight.
        /// </summary>
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
    }
}