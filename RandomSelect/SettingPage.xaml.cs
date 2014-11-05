using System;
using System. Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace RandomSelect
{
    public partial class SettingPage : PhoneApplicationPage
    {
        #region 获取设置状态
        public SettingPage( )
        {
            InitializeComponent( );
            storyboard_1.Begin();
            //this. Loaded += (s, e) =>
            //{
            this.toggleSkin.IsChecked = Config.IsBackground;
            this.toggleSound.IsChecked = Config.IsSound;
            this.pikerPage.SelectionChanged += pikerPage_SelectionChanged;
            this.pikerPage.SelectedIndex = Config.PageIndex;

            Color color = ToColor(Config.themeColorPath);
            text_color.Foreground = new SolidColorBrush(color);
            this.color_piker.Color = color;
            //};
        }
        #endregion
        private void toggleSkin_Checked(object sender, RoutedEventArgs e)
        {
            Config.IsBackground = (bool)this.toggleSkin.IsChecked;
            this.toggleSkin.Content = ((bool)this.toggleSkin.IsChecked) ? "自定义" : "默认";
        }
        private void pikerPage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Config.PageIndex = this.pikerPage.SelectedIndex;
        }

        private void toggleSound_Checked(object sender, RoutedEventArgs e)
        {
            Config.IsSound = (bool)this.toggleSound.IsChecked;
            this.toggleSound.Content = ((bool)this.toggleSound.IsChecked) ? "开" : "关";
        }
        private void color_piker_ColorChanged(object sender, Color color)
        {
            text_color.Foreground = new SolidColorBrush(color_piker.Color);
            Config.themeColorPath = color_piker.Color.ToString();
        }
        #region 存储设置状态
        
        #endregion

        private void menuItemReset_Click(object sender, EventArgs e)
        {
            Config.PageIndex = 0;
            Config.IsBackground = false;
            Config.themeColorPath = "#FF1BA1E2";
            toggleSkin.IsChecked = false;
            pikerPage.SelectedIndex = 0;
            Color color = ToColor("#FF1BA1E2");
            text_color.Foreground = new SolidColorBrush(color);
            this.color_piker.Color = color;

        }
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.pikerPage.ListPickerMode == ListPickerMode.Expanded)
            {
                e.Cancel = true;
            }
            else
            {
                storyboard_2.Begin();
                base.OnBackKeyPress(e);
            }
        }

        private Color ToColor(string colorName)
        {
            //16进制转换成颜色
            if (colorName.StartsWith("#"))
                colorName = colorName.Replace("#", string.Empty);
            int v = int.Parse(colorName, System.Globalization.NumberStyles.HexNumber);
            return new Color()
            {
                A = Convert.ToByte((v >> 24) & 255),
                R = Convert.ToByte((v >> 16) & 255),
                G = Convert.ToByte((v >> 8) & 255),
                B = Convert.ToByte((v >> 0) & 255)
            };
        }
    }
}