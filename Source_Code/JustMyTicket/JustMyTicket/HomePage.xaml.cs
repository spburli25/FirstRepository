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
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;

namespace JustMyTicket
{
    public partial class HomePage : PhoneApplicationPage
    {
        
        App thisApp = Application.Current as App;
        BusReference.Service1Client bobj = null;
        public HomePage()
        {
            InitializeComponent();
            bobj = new BusReference.Service1Client();
            btnTicket.Visibility = Visibility.Collapsed;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //BusReference.RentAppServiceClient objService = new RentenantServices.RentAppServiceClient();
            //objService.loginCompleted += new EventHandler<RentenantServices.loginCompletedEventArgs>(objService_loginCompleted);
            //objService.loginAsync(txtEmailIdTitle.Text, txtPasswordTitle.Password.ToString());
        }
        //private void objService_loginCompleted(object sender, RentenantServices.loginCompletedEventArgs e)
        //{
        //    bool res = e.Result;
        //    if (res.Equals(true))
        //        NavigationService.Navigate(new Uri("/.xaml", UriKind.Relative));
        //    else
        //        MessageBox.Show("Invalid User !");
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FBLogin.xaml", UriKind.RelativeOrAbsolute));
            btnLogin.Visibility = Visibility.Collapsed;
            btnSignUp.Visibility = Visibility.Collapsed;
            btnLoginFB.Visibility = Visibility.Collapsed;

            txtEmailId.Visibility = Visibility.Collapsed;
            txtEmailIDValue.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Collapsed;
            pwdboxValue.Visibility = Visibility.Collapsed;
          
            btnTicket.Visibility = Visibility.Visible;


        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            this.textBlock1.Text = thisApp.UserName;
         
            BitmapImage bitmap = new BitmapImage(new Uri(thisApp.UserImage, UriKind.RelativeOrAbsolute));
            this.image1.Source = bitmap;
           

        }

        private void btnTicket_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/UserProfile.xaml", UriKind.RelativeOrAbsolute));
            //NavigationService.Navigate(new Uri("/Payment.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bobj.loginAsync(txtEmailIDValue.Text,pwdboxValue.Password);
            bobj.loginCompleted+=new EventHandler<BusReference.loginCompletedEventArgs>(bobj_loginCompleted);
        }
        public void bobj_loginCompleted(object sender,BusReference.loginCompletedEventArgs e )
        {
            if (!e.Result.Equals(""))
            {
                PhoneApplicationService.Current.State["Email"] = e.Result.ToString();
                NavigationService.Navigate(new Uri("/UserProfile.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Please enter correct values !");
            }

        }
    }
}
