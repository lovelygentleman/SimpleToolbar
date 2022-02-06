using System;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Application = System.Windows.Application;
using System.Threading;

namespace Toolbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MuteSymbol.Visibility = Visibility.Hidden;
            UnmuteSymbol.Visibility = Visibility.Visible;      
        }


    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            MuteSymbol.Visibility = Visibility.Visible;
            UnmuteSymbol.Visibility = Visibility.Hidden;
            var audioController = new CoreAudioController();
            var devices = await audioController.GetDevicesAsync(DeviceType.Capture, DeviceState.Active);
            var device = devices.FirstOrDefault(x => x.IsDefaultDevice);
            if (device != null)
            {
                device.ToggleMute();
            }
        }

        private async void UnmuteButton_Click(object sender, RoutedEventArgs e)
        {
            MuteSymbol.Visibility = Visibility.Hidden;
            UnmuteSymbol.Visibility = Visibility.Visible;
            var audioController = new CoreAudioController();
            var devices = await audioController.GetDevicesAsync(DeviceType.Capture, DeviceState.Active);
            var device = devices.FirstOrDefault(x => x.IsDefaultDevice);
            if (device != null)
            {
                device.ToggleMute();
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe");
        }

        private void NoteButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void FlightButton_Click(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("https://fltplan.com/");
        }
    }
}


