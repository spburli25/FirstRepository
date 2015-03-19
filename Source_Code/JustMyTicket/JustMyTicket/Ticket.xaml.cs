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

namespace JustMyTicket
{
    public partial class Ticket : PhoneApplicationPage
    {
        BusReference.Service1Client busDetail = null;
        public Ticket()
        {
            InitializeComponent();

            Bus_No.Text = PhoneApplicationService.Current.State["Bus_No"].ToString();
            Distance.Text = PhoneApplicationService.Current.State["Distance"].ToString();
            Source.Text = PhoneApplicationService.Current.State["Source"].ToString();
            Destination.Text = PhoneApplicationService.Current.State["Destination"].ToString();
            Duration.Text = PhoneApplicationService.Current.State["Duration"].ToString();
        }
        
    }
}