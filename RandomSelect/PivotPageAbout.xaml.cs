using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;
using System;
using Windows.System;

namespace RandomSelect
{
    public partial class PivotPageAbout : PhoneApplicationPage
    {
        public PivotPageAbout()
        {
            InitializeComponent();
            storyboard_1.Begin();
        }

        private void version_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //登录商店
            MarketplaceDetailTask task = new MarketplaceDetailTask { };
            task.Show();
        }

        private void email_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string OSVersion = Environment.OSVersion.ToString();   //OS版本
            string manufacturer = DeviceStatus.DeviceManufacturer.ToString();       //硬件厂商
            string name = DeviceStatus.DeviceName.ToString();   //设备型号
            //发送电子邮件
            EmailComposeTask task = new EmailComposeTask
            {
                To = "lython@live.cn",
                Subject = "[Lython]" + this.aboutPivot.Title.ToString() + version.Label.ToString(),
                Body = "\n\n\nOEM：" + manufacturer + "\nPHONE：" + name + "\nVERSION：" + OSVersion,
            };
            task.Show();
        }

        private void star_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //评价
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void update_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //登录商店
            MarketplaceDetailTask task = new MarketplaceDetailTask { };
            task.Show();
        }

        private void shareapp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //发送短信
            string content = "选择恐惧症？下载它http://www.windowsphone.com/s?appid=52a5bb3f-a789-4993-85cb-1da2a0d55260，帮你选择。";
            SmsComposeTask task = new SmsComposeTask
            {
                Body = content,
            };
            task.Show();
        }

        private async void moreapp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //更多App
            await Launcher.LaunchUriAsync(new System.Uri("zune:search?publisher=Lython"));
        }
        private void OnAppbarBackClick(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            storyboard_2.Begin();
        }

        
    }
}
