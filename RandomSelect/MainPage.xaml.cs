using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Audio;

namespace RandomSelect
{
    public partial class MainPage : PhoneApplicationPage
    {

        private DispatcherTimer timer_dice = new DispatcherTimer(); //骰子定时器
        private int dice_index = 0;
        private int dice_count = 0;

        PhotoChooserTask photoChooser = new PhotoChooserTask();  //照片选择器

        //DispatcherTimer timer_puker = new DispatcherTimer();

        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            photoChooser.Completed += new EventHandler<PhotoResult>(OnPhotoChooserCompleted);
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            timer_dice.Interval = TimeSpan.FromMilliseconds(50);
            timer_dice.Tick += OnTimerDice;

            this.myPivot.SelectedIndex = Config.PageIndex;
            randomSelectPuck();
            randomSelectPuck();

            //timer_puker.Interval = TimeSpan.FromMilliseconds(33);
            //timer_puker.Tick += delegate { try { Microsoft.Xna.Framework.FrameworkDispatcher.Update(); } catch { } };
            //timer_puker.Start();
        }

        private void btn_tab_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Name;
            string str = name.Substring(name.Length-1, 1);
            int index = Convert.ToInt16(str);
            myPivot.SelectedIndex = index;
        }

        //骰子
        private void tile_dice_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (timer_dice.IsEnabled)
            {
                OnDiceStop();
            }
            else
            {
                timer_dice.Start();
                tile_dice.IsHitTestVisible = false;
                if (Config.IsSound) playSoundEffect("Sound/dice.wav");
            }
        }

        void OnTimerDice(object sender, EventArgs e)
        {
            OnDiceStart();
        }

        void OnDiceStart()
        {
            dice_count++;
            dice_index++;
            Uri uri = new Uri(String.Format("/RandomSelect;component/Dice/dice_action_{0}.png", dice_index), UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_dice.Source = bmp;
            if (dice_index >= 4) dice_index = 0;
            if (dice_count >= 26) OnDiceStop();

        }

        void OnDiceStop()
        {
            timer_dice.Stop();
            Random ro = new Random();
            Uri uri = new Uri(String.Format("/RandomSelect;component/Dice/dice_{0}.png", ro.Next(1, 7)), UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_dice.Source = bmp;
            dice_count = 0;
            dice_index = 0;
            tile_dice.IsHitTestVisible = true;
        }

        //扑克
        private void tile_poker_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Uri uri = new Uri("/RandomSelect;component/Poker/0.png", UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_poker.Source = bmp;
            rotateX.Begin();
            tile_poker.IsHitTestVisible = false;
            if (Config.IsSound) playSoundEffect("Sound/poker.wav");
            //else rotateX.Duration = new TimeSpan(1000);
        }

        private void rotateX_Completed(object sender, EventArgs e)
        {
            tile_poker.IsHitTestVisible = true;
            randomSelectPuck();
        }

        void randomSelectPuck()
        {
            Random ro = new Random();
            Uri uri = new Uri(String.Format("/RandomSelect;component/Poker/{0}.png", ro.Next(1, 55)), UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_poker.Source = bmp;
        }

        //石头、剪刀、布
        private void tile_sjb_Tap(object sender, RoutedEventArgs e) //tile_sjb_Tap
        {
            Random ro = new Random();
            Uri uri = new Uri("/RandomSelect;component/SJB/sjb_left_0.png", UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_sjb_left.Source = bmp;

            Uri uri_right = new Uri("/RandomSelect;component/SJB/sjb_right_0.png", UriKind.Relative);
            BitmapImage bmp_right = new BitmapImage(uri_right);
            img_sjb_right.Source = bmp_right;
            rotateZ.Begin();
            tile_sjb.IsHitTestVisible = false;
            if (Config.IsSound) playSoundEffect("Sound/liuhejing.wav");
        }

        private void rotateZ_Completed(object sender, EventArgs e)
        {
            Random ro = new Random();
            Uri uri = new Uri(String.Format("/RandomSelect;component/SJB/sjb_left_{0}.png", ro.Next(0, 3)), UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            img_sjb_left.Source = bmp;

            Uri uri_right = new Uri(String.Format("/RandomSelect;component/SJB/sjb_right_{0}.png", ro.Next(0, 3)), UriKind.Relative);
            BitmapImage bmp_right = new BitmapImage(uri_right);
            img_sjb_right.Source = bmp_right;
            tile_sjb.IsHitTestVisible = true;
        }

        //颜色
        private void tile_dial_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            rotateDial.Begin();
            tile_dial.IsHitTestVisible = false;
            if (Config.IsSound) playSoundEffect("Sound/dial.wav");
        }

        private void rotateDial_Completed(object sender, EventArgs e)
        {
            tile_dial.IsHitTestVisible = true;
            Random ro = new Random();
            planeProjectionZ.RotationZ = ro.Next(0, 360);
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

        private void myPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = this.myPivot.SelectedIndex;
            if (index == 0)
            {
                btn_tab_0.BorderBrush = new SolidColorBrush(Colors.White);
                btn_tab_1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            else if (index == 1)
            {
                btn_tab_0.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_1.BorderBrush = new SolidColorBrush(Colors.White);
                btn_tab_2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            else if (index == 2)
            {
                btn_tab_0.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_2.BorderBrush = new SolidColorBrush(Colors.White);
                btn_tab_3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            else if (index == 3)
            {
                btn_tab_0.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn_tab_3.BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void appbar_settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingPage.xaml", UriKind.Relative));
        }

        private void appbar_about_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPageAbout.xaml", UriKind.Relative));
        }

        private void appbar_skin_Click(object sender, EventArgs e)
        {
            photoChooser.PixelWidth = 768;
            photoChooser.PixelHeight = 1280;
            photoChooser.ShowCamera = true;
            photoChooser.Show();
        }

        void OnPhotoChooserCompleted(object sender, PhotoResult e)
        {
            if (e.Error == null && e.ChosenPhoto != null)
            {
                ImageBrush img = new ImageBrush();
                WriteableBitmap bmp = Microsoft.Phone.PictureDecoder.DecodeJpeg(e.ChosenPhoto);
                IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
                string filename = e.OriginalFileName.Substring(e.OriginalFileName.LastIndexOf('\\') + 1);
                if (isf.FileExists(filename)) //如果已经存在这个文件，则将这个文件删除
                {
                    isf.DeleteFile(filename);
                }
                IsolatedStorageFileStream PhotoStream = isf.CreateFile(filename);
                Extensions.SaveJpeg(bmp, PhotoStream, bmp.PixelWidth, bmp.PixelHeight, 0, 85); //这里设置保存后图片的大
                PhotoStream.Close();    //写入完毕，关闭文件流

                img.ImageSource = bmp;
                this.LayoutRoot.Background = img;
                //if (isf.FileExists(Config.BackImg)) isf.DeleteFile(Config.BackImg); //删除上一个皮肤，WP8里面会报错
                Config.BackImg = filename;
                Config.IsBackground = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            try
            {
                ImageBrush img = new ImageBrush();
                BitmapImage bmp = new BitmapImage();
                if (Config.IsBackground == true)
                {
                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(Config.BackImg, FileMode.Open, FileAccess.Read))
                        {
                            bmp.SetSource(fileStream);
                            img.ImageSource = bmp;
                        }
                    }
                }
                else
                {
                    Uri uri = new Uri("Assets/bing.jpg", UriKind.Relative);
                    bmp.UriSource = uri;
                    img.ImageSource = bmp;
                }
                this.LayoutRoot.Background = img;
            }
            catch { }
            Color color = ToColor(Config.themeColorPath);
            bar_top.Background = new SolidColorBrush(color);
            ApplicationBar.BackgroundColor = color;
        }

        private void playSoundEffect(string filename)
        {
            //播放提示音乐
            Stream stream = null;
            //StreamResourceInfo info = Application.GetResourceStream(new Uri("Source/alarm.wav", UriKind.Relative));
            StreamResourceInfo info = Application.GetResourceStream(new Uri(filename, UriKind.Relative));
            if (stream == null) stream = info.Stream;
            SoundEffect sound = SoundEffect.FromStream(stream);
            SoundEffectInstance soundInstance = sound.CreateInstance();
            //Microsoft.Xna.Framework.FrameworkDispatcher.Update();
            //soundInstance.IsLooped = true;
            soundInstance.Play();
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}