using Coding4Fun.Toolkit.Controls;
using Easy_Weight.Model;
using Microsoft.Phone.Controls;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "No file to load. ";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
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

                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "Weight recorded successfully.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
            }
            catch (System.FormatException f)
            {
                if (weights.weightList.Count() > 1)
                {
                    weights.weightList.RemoveAt(weights.weightList.Count() - 1);
                }

                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "Please input a whole number.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
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

                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "New goal weight set.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
            }
            catch (System.FormatException f)
            {
                weights.weightList[0] = currGoal;

                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "Please input a whole number.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
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

                BitmapImage tn = new BitmapImage(new Uri("/Assets/Images/BlueTurtle.png", UriKind.Relative));
                turtle.Source = tn; 
            }
            else if (weights.weightList.Count < 3 || Math.Abs(currentI - goalI) < Math.Abs(lastI - goalI))
            {
                weight.Foreground = new SolidColorBrush(Color.FromArgb(255, 140, 191, 35));

                BitmapImage tn = new BitmapImage(new Uri("/Assets/Images/GreenTurtle.png", UriKind.Relative));
                turtle.Source = tn; 
            }
            else
            {
                weight.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

                BitmapImage tn = new BitmapImage(new Uri("/Assets/Images/RedTurtle.png", UriKind.Relative));
                turtle.Source = tn; 
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            var messagePrompt = new MessagePrompt
            {
                Title = "WARNIGN",
                Message = "Are you sure you want to delete all previous entries?",
                IsCancelVisible = true
            };

            messagePrompt.Completed += messagePrompt_Completed;
            messagePrompt.Show();
        }

        private async void messagePrompt_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.PopUpResult == PopUpResult.Ok)
            {
                weights.clear();

                weight.Text = "000";
                weights.weightList.Add("000");
                await weights.writeJsonAsync();

                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "Weights succesfully reset.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
            }
            else
            {
                ToastPrompt toast = new ToastPrompt();
                toast.Title = "Easy Weight";
                toast.Message = "Weights not reset.";
                toast.MillisecondsUntilHidden = 2000;
                toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));

                toast.Show();
            }
        }
    }
}