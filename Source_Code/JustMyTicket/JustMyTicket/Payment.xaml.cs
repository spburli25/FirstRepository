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
    public partial class Payment : PhoneApplicationPage
    {
        public Payment()
        {
            InitializeComponent();
        }
        string data;
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
    }
}