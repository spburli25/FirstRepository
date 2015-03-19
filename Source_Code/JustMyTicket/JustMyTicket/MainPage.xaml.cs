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
using Microsoft.Phone.Shell;
using System.Device.Location;

namespace JustMyTicket
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        private GeoCoordinateWatcher loc = null;
        BusReference.Service1Client busDetail = null;
        public MainPage()
        {
            InitializeComponent();
            loc = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            busDetail = new BusReference.Service1Client();
            //loc.StatusChanged += new EventHandler<System.Device.Location.GeoPositionStatusChangedEventArgs>(loc_StatusChanged);
            loc.PositionChanged += new EventHandler<System.Device.Location.GeoPositionChangedEventArgs<GeoCoordinate>>(loc_PositionChanged);
            if (loc.Status == GeoPositionStatus.Disabled)
            {
                MessageBox.Show("Location services must be enabled");
                return;
            }
            loc.Start();
            txtDateValue.Text = System.DateTime.Now.ToString();
            txtBusNoValue .Text= PhoneApplicationService.Current.State["Bus_No"].ToString();
            txtDistanceValue.Text = PhoneApplicationService.Current.State["Distance"].ToString();
            txtRoute.Text = PhoneApplicationService.Current.State["Source"].ToString() + " - " + PhoneApplicationService.Current.State["Destination"].ToString();
            //txtTimeValue.Text = System.DateTime.Today.ToString();
            txtDuration.Text = PhoneApplicationService.Current.State["Duration"].ToString();
        }
        void loc_PositionChanged(object sender, System.Device.Location.GeoPositionChangedEventArgs<GeoCoordinate> e)
        {

            //LatitudeTextBlock.Text = e.Position.Location.Latitude.ToString();
            //LongitudeTextBlock.Text = e.Position.Location.Longitude.ToString();
            busDetail.RetrieveFormatedAddressAsync(e.Position.Location.Latitude.ToString(), e.Position.Location.Longitude.ToString());
            busDetail.RetrieveFormatedAddressCompleted += new EventHandler<BusReference.RetrieveFormatedAddressCompletedEventArgs>(busDetail_RetrieveFormatedAddressCompleted);

        }
        void busDetail_RetrieveFormatedAddressCompleted(object sender, BusReference.RetrieveFormatedAddressCompletedEventArgs ee)
        {
           if(ee.Result.ToString().Equals(PhoneApplicationService.Current.State["Destination"].ToString()))
           {
               txtStatusValue.Text = "Expired";
           }
         }
    }
}