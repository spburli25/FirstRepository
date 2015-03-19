using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;

namespace JustMyTicket
{
    public partial class UserProfile : PhoneApplicationPage
    {
        private GeoCoordinateWatcher loc = null;
        MapLayer markerLayer = null;
        BusReference.Service1Client busDetail = null;
        string MyLocation,Source, Destination="",CurrentLocation;
        public UserProfile()
        {
            InitializeComponent();
            
            busDetail = new BusReference.Service1Client();
            //busDetail.Current_BalanceAsync(PhoneApplicationService.Current.State["Email"].ToString());
            //busDetail.Current_BalanceCompleted+=new EventHandler<BusReference.Current_BalanceCompletedEventArgs>(busDetail_Current_BalanceCompleted);
            map1.ZoomBarVisibility = Visibility.Visible;
            loc = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            loc.StatusChanged += new EventHandler<System.Device.Location.GeoPositionStatusChangedEventArgs>(loc_StatusChanged);
           // loc.PositionChanged += new EventHandler<System.Device.Location.GeoPositionChangedEventArgs<GeoCoordinate>>(loc_PositionChanged);
            if (loc.Status == GeoPositionStatus.Disabled)
            {
                MessageBox.Show("Location services must be enabled");
                return;
            }
            markerLayer = new MapLayer();
            map1.Children.Add(markerLayer);
            loc.Start();
        }
        string data;
        public void busDetail_Current_BalanceCompleted(object sender,BusReference.Current_BalanceCompletedEventArgs e)
        {
            //txtBalance.Text = (e.Result.Bus_Money).ToString();
        }
        private void txtNameOnCard_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtCardNo_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtYear_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtCVV_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtNameOnCard_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtCardNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtYear_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }


        private void txtCVV_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }
        }


        private void txtAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }
        void loc_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                Pushpin locationPushpin = new Pushpin();
                locationPushpin.Background = new SolidColorBrush(Colors.Red);
                locationPushpin.Content = "You are here";
                locationPushpin.Tag = "locationPushpin";
                locationPushpin.Location = loc.Position.Location;
                this.map1.Children.Add(locationPushpin);
                this.map1.SetView(loc.Position.Location, 10.0);
                loc.Stop();
                GeoCoordinate value = new GeoCoordinate();
                value.Latitude = loc.Position.Location.Latitude;
                value.Longitude = loc.Position.Location.Longitude;
                busDetail.RetrieveFormatedAddressAsync(value.Latitude.ToString(), value.Longitude.ToString());
                busDetail.RetrieveFormatedAddressCompleted+=new EventHandler<BusReference.RetrieveFormatedAddressCompletedEventArgs>(busDetail_RetrieveFormatedAddressCompleted);
            }
        }

        public void btnPayNow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recharge done for "+txtAmount.Text+" !");
            //busDetail.payMoneyAsync(PhoneApplicationService.Current.State["Email"].ToString(), int.Parse(txtAmount.Text));
            //busDetail.payMoneyCompleted+=new EventHandler<BusReference.payMoneyCompletedEventArgs>(busDetail_payMoneyCompleted);
        }
        public void busDetail_payMoneyCompleted(object sender, BusReference.payMoneyCompletedEventArgs e)
        {
            //if (e.Result == true)
            //    MessageBox.Show("Your recharged " + txtAmount.Text + " Successfully.");
            //else
            //    MessageBox.Show("Error Occured try again !");
        }
        //void loc_PositionChanged(object sender, System.Device.Location.GeoPositionChangedEventArgs<GeoCoordinate> e)
        //{
        //    GeoCoordinate value = new GeoCoordinate();
        //    value.Latitude = e.Position.Location.Latitude;
        //    value.Longitude = e.Position.Location.Longitude;
        //    busDetail.RetrieveFormatedAddressAsync(value.Latitude.ToString(), value.Longitude.ToString());
        //    busDetail.RetrieveFormatedAddressCompleted += new EventHandler<BusReference.RetrieveFormatedAddressCompletedEventArgs>(busDetail_RetrieveFormatedAddressCompleted);
            
        //}
        private void ToAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                    PhoneApplicationService.Current.State["Source"] ="Hebbal";
                    PhoneApplicationService.Current.State["Destination"] = ToAddress.Text;
                    NavigationService.Navigate(new Uri("/BusInformation.xaml", UriKind.Relative));

            }
        }

        void busDetail_RetrieveFormatedAddressCompleted(object sender, BusReference.RetrieveFormatedAddressCompletedEventArgs e)
        {
            Source = e.Result;       
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Amount credited Successfully"+ txtAmount.Text);
        }
       
    }
}