using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DroneControl.Resources;
using DroneControl.Commands;

namespace DroneControl
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ControlConnection ControlChannel { get; set; }
        private StatusConnection StatusChannel { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ShowControlPanel()
        {
            ConnectionPanel.Visibility = Visibility.Visible;
            FlightPanel.Visibility = Visibility.Collapsed;
        }

        private void ShowFlightPanel()
        {
            ConnectionPanel.Visibility = Visibility.Collapsed;
            FlightPanel.Visibility = Visibility.Visible;
        }

        private async void OnConnectClick(object sender, RoutedEventArgs e)
        {
            ConnectDrone(DroneAddress.Text);
            ShowFlightPanel();
        }

        private void OnDisconnectButtonClick(object sender, RoutedEventArgs e)
        {
            if (ControlChannel != null && ControlChannel.IsConnected)
            {
                ControlChannel.Close();
            }

            if (StatusChannel != null && StatusChannel.IsConnected)
            {
                StatusChannel.Close();
            }

            ShowControlPanel();
        }

        private async void OnTakeOffButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ControlChannel.IsConnected)
            {
                return;
            }

            ControlCommand command = new TakeOffCommand(ControlChannel);
            await command.Execute();
        }

        private async void OnLandButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ControlChannel.IsConnected)
            {
                return;
            }

            ControlCommand command = new LandCommand(ControlChannel);
            await command.Execute();
        }

        private async void OnEmergencyButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ControlChannel.IsConnected)
            {
                return;
            }

            ControlCommand command = new EmergencyCommand(ControlChannel);
            await command.Execute();
        }

        private async void ConnectDrone(string address)
        {
            ConnectDroneControlChannel(address);
            ConnectDroneStatusChannel(address);
        }

        private async void ConnectDroneControlChannel(string address)
        {
            ControlChannel = new ControlConnection(address);
            await ControlChannel.Connect();
        
            // Test that the control channel is connected
            ControlCommand command = new LedCommand(ControlChannel, LedCommand.AnimationType.BlinkGreen, TimeSpan.FromSeconds(1), 5);
            await command.Execute();
        }

        private async void ConnectDroneStatusChannel(string address)
        {
            StatusChannel = new StatusConnection(address);
            await StatusChannel.Connect();
            //await StatusChannel.StartStatusStream();

            // Test that the control channel is connected
            ControlCommand command = new LedCommand(ControlChannel, LedCommand.AnimationType.BlinkOrange, TimeSpan.FromSeconds(1), 5);
            await command.Execute();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}