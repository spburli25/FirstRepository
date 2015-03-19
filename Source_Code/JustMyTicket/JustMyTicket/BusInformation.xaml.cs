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
using Microsoft.Phone.Tasks;

namespace JustMyTicket
{
    public partial class BusInformation : PhoneApplicationPage
    {
        BusReference.Service1Client busDetail = null;
        string distance, duration;
        List<string> busInfo = new List<string>();
        List<BusReference.Bus> result = null;
        public BusInformation()
        {
            InitializeComponent();
            busDetail = new BusReference.Service1Client();
            result=new List<BusReference.Bus>();
            //busDetail.BusDetailsAsync(PhoneApplicationService.Current.State["Source"].ToString(),PhoneApplicationService.Current.State["Destination"].ToString());
            //busDetail.BusDetailsCompleted += new EventHandler<BusReference.BusDetailsCompletedEventArgs>(busDetailsInfo);
            busDetail.BusRouteAsync(PhoneApplicationService.Current.State["Source"].ToString(), PhoneApplicationService.Current.State["Destination"].ToString());
            busDetail.BusRouteCompleted+=new EventHandler<BusReference.BusRouteCompletedEventArgs>(busDetail_BusRouteCompleted);
       }
       //void busDetailsInfo(object sender, BusReference.BusDetailsCompletedEventArgs e)
       // {
       //     string s = e.Result;
       //     string[] values = s.Split('*');
       //     distance = values[0];
       //     duration = values[1];
       //     string number = values[2];
       //     values = number.Split(',');
       //     string fin = String.Empty;
       //     foreach (string i in values)
       //     {
       //         busInfo.Add(i+" "+ distance+" "+duration);
       //     }
       //     BusList.ItemsSource = busInfo;
       // }
       void busDetail_BusRouteCompleted(object sender,BusReference.BusRouteCompletedEventArgs ee)
       {
           foreach (BusReference.Bus item in ee.Result)
           {
               result.Add(item);
           }
           if (result.Count == 0)
           {
               MessageBox.Show("We couldn't find the place");
               NavigationService.Navigate(new Uri("/UserProfile.xaml", UriKind.Relative));
           }

           BusList.ItemsSource = result;
       }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = BusList.SelectedIndex;
            index=index + 1;
            BusReference.Bus res = result.ElementAt(index);
            PhoneApplicationService.Current.State["Distance"] = res.Distance;
            PhoneApplicationService.Current.State["Duration"] = res.Duration;
            PhoneApplicationService.Current.State["Bus_No"] = res.Bus_No;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            
            
                
        }



    }
}