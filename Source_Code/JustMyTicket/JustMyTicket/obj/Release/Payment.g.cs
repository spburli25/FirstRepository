﻿#pragma checksum "C:\Apps\JustMyTicket\JustMyTicket\Payment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8C843869079A7F81217B4217AA89C63C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace JustMyTicket {
    
    
    public partial class Payment : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image image1;
        
        internal System.Windows.Controls.RadioButton radioButton1;
        
        internal System.Windows.Controls.RadioButton radioButton2;
        
        internal System.Windows.Controls.TextBox txtNameOnCard;
        
        internal System.Windows.Controls.TextBox txtCardNo;
        
        internal System.Windows.Controls.TextBox txtMonth;
        
        internal System.Windows.Controls.TextBox txtYear;
        
        internal System.Windows.Controls.TextBox txtCVV;
        
        internal System.Windows.Controls.Button button1;
        
        internal System.Windows.Controls.TextBlock txtBalance;
        
        internal System.Windows.Controls.TextBlock txtMyacc;
        
        internal System.Windows.Controls.TextBox textBox3;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/JustMyTicket;component/Payment.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
            this.radioButton1 = ((System.Windows.Controls.RadioButton)(this.FindName("radioButton1")));
            this.radioButton2 = ((System.Windows.Controls.RadioButton)(this.FindName("radioButton2")));
            this.txtNameOnCard = ((System.Windows.Controls.TextBox)(this.FindName("txtNameOnCard")));
            this.txtCardNo = ((System.Windows.Controls.TextBox)(this.FindName("txtCardNo")));
            this.txtMonth = ((System.Windows.Controls.TextBox)(this.FindName("txtMonth")));
            this.txtYear = ((System.Windows.Controls.TextBox)(this.FindName("txtYear")));
            this.txtCVV = ((System.Windows.Controls.TextBox)(this.FindName("txtCVV")));
            this.button1 = ((System.Windows.Controls.Button)(this.FindName("button1")));
            this.txtBalance = ((System.Windows.Controls.TextBlock)(this.FindName("txtBalance")));
            this.txtMyacc = ((System.Windows.Controls.TextBlock)(this.FindName("txtMyacc")));
            this.textBox3 = ((System.Windows.Controls.TextBox)(this.FindName("textBox3")));
        }
    }
}

