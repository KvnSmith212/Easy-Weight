﻿#pragma checksum "C:\Users\kvnsm_000\documents\visual studio 2013\Projects\Easy Weight\Easy Weight\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BEDAA1D263FDB6514AF75EF48D46161"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace Easy_Weight {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock weight;
        
        internal System.Windows.Controls.TextBox new_weight;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Easy%20Weight;component/MainPage.xaml", System.UriKind.Relative));
            this.weight = ((System.Windows.Controls.TextBlock)(this.FindName("weight")));
            this.new_weight = ((System.Windows.Controls.TextBox)(this.FindName("new_weight")));
        }
    }
}

