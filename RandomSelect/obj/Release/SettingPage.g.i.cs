﻿#pragma checksum "E:\Windows Phone\提交App\选择恐惧症\1.0.0.3\RandomSelect\RandomSelect\SettingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "23D477C2D7F4A582A3E790B40121B813"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34011
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Phone.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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
    
    
    public partial class SettingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.TranslateTransform translate;
        
        internal System.Windows.Media.Animation.Storyboard storyboard_1;
        
        internal System.Windows.Media.Animation.Storyboard storyboard_2;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot settingsPage;
        
        internal Microsoft.Phone.Controls.ToggleSwitch toggleSkin;
        
        internal Microsoft.Phone.Controls.ToggleSwitch toggleSound;
        
        internal Microsoft.Phone.Controls.ListPicker pikerPage;
        
        internal System.Windows.Controls.TextBlock text_color;
        
        internal Coding4Fun.Phone.Controls.ColorHexagonPicker color_piker;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem menuItemReset;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RandomSelect;component/SettingPage.xaml", System.UriKind.Relative));
            this.translate = ((System.Windows.Media.TranslateTransform)(this.FindName("translate")));
            this.storyboard_1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboard_1")));
            this.storyboard_2 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboard_2")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.settingsPage = ((Microsoft.Phone.Controls.Pivot)(this.FindName("settingsPage")));
            this.toggleSkin = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("toggleSkin")));
            this.toggleSound = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("toggleSound")));
            this.pikerPage = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("pikerPage")));
            this.text_color = ((System.Windows.Controls.TextBlock)(this.FindName("text_color")));
            this.color_piker = ((Coding4Fun.Phone.Controls.ColorHexagonPicker)(this.FindName("color_piker")));
            this.menuItemReset = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("menuItemReset")));
        }
    }
}

