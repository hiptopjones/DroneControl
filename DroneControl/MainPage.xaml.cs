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
        private IControlConnection Connection { get; set; }
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

        private void OnConnectClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null || !Connection.IsConnected)
            {
                Connection = new ControlConnection(DroneAddress.Text);
                Connection.Connect();

                ShowFlightPanel();
            }
        }

        private async void OnTakeOffButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Connection.IsConnected)
            {
                return;
            }

            ControlCommand command = new TakeOffCommand(Connection);
            await command.Execute();
        }

        private async void OnLandButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Connection.IsConnected)
            {
                return;
            }

            ControlCommand command = new LandCommand(Connection);
            await command.Execute();
        }

        private void OnDisconnectButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Connection.IsConnected)
            {
                return;
            }

            Connection.Close();

            ShowControlPanel();
        }

        private async void OnEmergencyButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Connection.IsConnected)
            {
                return;
            }

            ControlCommand command = new EmergencyCommand(Connection);
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