﻿#pragma checksum "C:\Users\LIJ\Desktop\RandomSelect\RandomSelect\PivotPageAbout.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BFE855D2BD7034F5FDDE117B16C0DC1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34003
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Toolkit.Controls;
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


namespace RandomSelect {
    
    
    public partial class PivotPageAbout : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.TranslateTransform translate;
        
        internal System.Windows.Media.Animation.Storyboard storyboard_1;
        
        internal System.Windows.Media.Animation.Storyboard storyboard_2;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot aboutPivot;
        
        internal Coding4Fun.Toolkit.Controls.Tile version;
        
        internal Coding4Fun.Toolkit.Controls.Tile email;
        
        internal Coding4Fun.Toolkit.Controls.Tile star;
        
        internal Coding4Fun.Toolkit.Controls.Tile moreapp;
        
        internal Coding4Fun.Toolkit.Controls.Tile shareapp;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RandomSelect;component/PivotPageAbout.xaml", System.UriKind.Relative));
            this.translate = ((System.Windows.Media.TranslateTransform)(this.FindName("translate")));
            this.storyboard_1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboard_1")));
            this.storyboard_2 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboard_2")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.aboutPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("aboutPivot")));
            this.version = ((Coding4Fun.Toolkit.Controls.Tile)(this.FindName("version")));
            this.email = ((Coding4Fun.Toolkit.Controls.Tile)(this.FindName("email")));
            this.star = ((Coding4Fun.Toolkit.Controls.Tile)(this.FindName("star")));
            this.moreapp = ((Coding4Fun.Toolkit.Controls.Tile)(this.FindName("moreapp")));
            this.shareapp = ((Coding4Fun.Toolkit.Controls.Tile)(this.FindName("shareapp")));
        }
    }
}

