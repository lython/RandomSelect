using System;
using System. Collections. Generic;
using System. IO;
using System. IO. IsolatedStorage;
using Microsoft. Phone. Info;
using Microsoft. Phone. Shell;

namespace RandomSelect
{
    /// <summary>
    /// 配置类，保存设置里面的变量和用户信息
    /// </summary>
    public class Config
    {
        //默认页面
        public static int PageIndex
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("PageIndex") ?
                    (int)IsolatedStorageSettings.ApplicationSettings["PageIndex"] : 0;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["PageIndex"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        public static bool IsBackground
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("IsBackground") ?
                       (bool)IsolatedStorageSettings.ApplicationSettings["IsBackground"] : false;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["IsBackground"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        //背景图
        public static string BackImg
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("BackImg") ?
                       (string)IsolatedStorageSettings.ApplicationSettings["BackImg"] : null;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["BackImg"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        //音效
        public static bool IsSound
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("IsSound") ?
                       (bool)IsolatedStorageSettings.ApplicationSettings["IsSound"] : true;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["IsSound"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        public static string themeColorPath
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("themeColorPath") ?
                       (string)IsolatedStorageSettings.ApplicationSettings["themeColorPath"] : "#FF1BA1E2";
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["themeColorPath"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }
    }
}
