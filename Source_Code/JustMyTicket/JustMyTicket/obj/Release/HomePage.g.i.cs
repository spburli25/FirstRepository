﻿#pragma checksum "C:\Apps\JustMyTicket\JustMyTicket\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "21FB0C134BEC7BCC882406019C25E597"
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
    
    
    public partial class HomePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnLogin;
        
        internal System.Windows.Controls.Button btnSignUp;
        
        internal System.Windows.Controls.Button btnLoginFB;
        
        internal System.Windows.Controls.Image image1;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.Button btnTicket;
        
        internal System.Windows.Controls.TextBlock txtPassword;
        
        internal System.Windows.Controls.TextBlock txtEmailId;
        
        internal System.Windows.Controls.TextBox txtEmailIDValue;
        
        internal System.Windows.Controls.PasswordBox pwdboxValue;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/JustMyTicket;component/HomePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnLogin = ((System.Windows.Controls.Button)(this.FindName("btnLogin")));
            this.btnSignUp = ((System.Windows.Controls.Button)(this.FindName("btnSignUp")));
            this.btnLoginFB = ((System.Windows.Controls.Button)(this.FindName("btnLoginFB")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.btnTicket = ((System.Windows.Controls.Button)(this.FindName("btnTicket")));
            this.txtPassword = ((System.Windows.Controls.TextBlock)(this.FindName("txtPassword")));
            this.txtEmailId = ((System.Windows.Controls.TextBlock)(this.FindName("txtEmailId")));
            this.txtEmailIDValue = ((System.Windows.Controls.TextBox)(this.FindName("txtEmailIDValue")));
            this.pwdboxValue = ((System.Windows.Controls.PasswordBox)(this.FindName("pwdboxValue")));
        }
    }
}

