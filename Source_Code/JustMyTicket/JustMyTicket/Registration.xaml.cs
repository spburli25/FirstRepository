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

namespace JustMyTicket
{
    public partial class Registration : PhoneApplicationPage
    {
        BusReference.Service1Client objService = null;
        static BusReference.REGISTER newUser = null;
        public Registration()
        {
            InitializeComponent();
            objService = new BusReference.Service1Client();
            newUser = new BusReference.REGISTER();
        }
        string data;
        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            data = t.Text;
            t.Text = string.Empty;
            t.Background = new SolidColorBrush(Colors.Cyan);

        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Equals(string.Empty))
            {
                t.Text = data;
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            newUser.Email_ID = txtEmail.Text;
            newUser.Name = txtName.Text;
            newUser.Phone_Number = txtPhone.Text;
            newUser.Password = txtPassword.Text;
            newUser.Bus_Money = 50;
            newUser = new BusReference.REGISTER { Name = txtName.Text, Email_ID = txtEmail.Text, Phone_Number = txtPhone.Text, Password = txtPassword.Text, Bus_Money = 50 };
            objService.User_RegisterAsync(newUser);
            objService.User_RegisterCompleted += new EventHandler<BusReference.User_RegisterCompletedEventArgs>(objService_User_RegisterCompleted);
            //objService.User_RegisterCompleted +=new EventHandler<BusReference.User_RegisteredCompleted(objService_User_Completed);

        }

        public void objService_User_RegisterCompleted(object sender, BusReference.User_RegisterCompletedEventArgs e)
        {
            if (e.Result != "Failed !")
                NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
            else
            {
                MessageBox.Show("Signup failed, please try again !");
                txtName.Text = "";
                txtPassword.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";

            }

        }

    }
}