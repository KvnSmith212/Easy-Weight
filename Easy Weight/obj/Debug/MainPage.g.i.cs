﻿#pragma checksum "C:\Users\Kevin\Documents\Visual Studio 2013\Projects\Easy-Weight\Easy Weight\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C53E32B7D798BF32433801601C84EAA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
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
        
        internal System.Windows.Controls.Image turtle;
        
        internal System.Windows.Controls.TextBox new_weight;
        
        internal System.Windows.Controls.TextBox new_goal;
        
        internal System.Windows.Controls.Button reset;
        
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
            this.turtle = ((System.Windows.Controls.Image)(this.FindName("turtle")));
            this.new_weight = ((System.Windows.Controls.TextBox)(this.FindName("new_weight")));
            this.new_goal = ((System.Windows.Controls.TextBox)(this.FindName("new_goal")));
            this.reset = ((System.Windows.Controls.Button)(this.FindName("reset")));
        }
    }
}

