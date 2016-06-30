using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Windows.Foundation;
using Windows.Storage;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsAppText
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        // Write data to a file

        async void SaveClick(object sender, RoutedEventArgs e)
        {

            StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, textBox.Text);
        }

        // Read data from a file

        //Normally, you would want to return a Task. The main exception should be when you need to have a void return type (for events)
        private async void loadFile(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
                textBox.Text = await FileIO.ReadTextAsync(sampleFile);


            }
            catch (Exception)
            {
                textBox.Text = "No file found";
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
        


        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    textBox.Visibility = Visibility.Visible;
                    Clear.Visibility = Visibility.Visible;
                    Save.Visibility = Visibility.Visible;
                    Load.Visibility = Visibility.Visible;
                }
                 if(toggleSwitch.IsOn == false)
                {
                    textBox.Visibility = Visibility.Collapsed;
                    Clear.Visibility = Visibility.Collapsed;
                    Save.Visibility = Visibility.Collapsed;
                    Load.Visibility = Visibility.Collapsed;
                }
            }


        }



        //private void Enter(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        //{
        //    if (e.Key == Windows.System.VirtualKey.Enter)
        //    {


        //        textBox.Text = textBox.Text + Environment.NewLine;
        //    }
        //}
    }
}
