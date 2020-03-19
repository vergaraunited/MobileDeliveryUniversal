﻿// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MobileDeliveryUniversal.Helpers
{

    /*   Settings Plugin Readme
     *   See more at: https://github.com/jamesmontemagno/SettingsPlugin/blob/master/CHANGELOG.md
     *   ## News
     *   - Plugins have moved to.NET Standard and have some important changes! Please read my blog:
     *   http://motzcod.es/post/162402194007/plugins-for-xamarin-go-dotnet-standard

        -New changes in Settings API: GetValueOrDefault and AddOrUpdateValue are no longer generic and you must pass in only supported types.
        
        ### Important
        Ensure that you install NuGet into ALL projects.
        Create a new file called Settings.cs or whatever you want and copy this code in to get started:
    */

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                if (CrossSettings.IsSupported)
                    return CrossSettings.Current;

                return null; // or your custom implementation 
            }
        }
        public static void ClearAll()
        {
            AppSettings.Clear();
        }

        #region Setting Constants
        /*    
         *    <add key="LogPath" value="C:\apps\UnitedMobileDelivery\" />
         *    <add key="LogLevel" value="Debug" />
         *    <add key="Url" value="localhost" />
         *    <add key="Port" value="81" />
         *    <add key="WinsysUrl" value="localhost" />
         *    <add key="WinsysPort" value="8181" />
         *    <add key="UMDUrl" value="localhost" />
         *    <add key="UMDPort" value="81" />
         */

        private const string idLogPath = "LogPath";
        private static readonly string LogPathDefault = string.Empty;

        private const string idLogLevel = "LogLevel";
        private static readonly string LogLevelDefault = string.Empty;

        private const string idUrl = "Url";
        private static readonly string UrlDefault = string.Empty;

        private const string idPort = "Port";
        private static readonly int PortDefault = 0;

        private const string idWinsysUrl = "WinsysUrl";
        private static readonly string WinsysUrlDefault = string.Empty;

        private const string idWinsysPort = "WinsysPort";
        private static readonly int WinsysPortDefault = 8181;

        private const string idUMDUrl = "UMDUrl";
        private static readonly string UMDUrlDefault = GlobalSetting.Config.srvSet.umdurl;

        private const string idUMDPort = "UMDPort";
        private static readonly int UMDPortDefault = GlobalSetting.Config.srvSet.umdport;

        #endregion

        public static string LogLevel
        {
            get
            {
                return AppSettings.GetValueOrDefault(idLogLevel, LogLevelDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idLogLevel, value);
            }
        }

        public static string Url
        {
            get
            {
                return AppSettings.GetValueOrDefault(idUrl, UrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idUrl, value);
            }
        }
        private static int Port
        {
            get
            {
                return AppSettings.GetValueOrDefault(idPort, PortDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idPort, value);
            }
        }
       

        private static string WinsysUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(idWinsysUrl, WinsysUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idWinsysUrl, value);
            }
        }

        private static int WinsysPort
        {
            get
            {
                return AppSettings.GetValueOrDefault(idWinsysPort, WinsysPortDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idWinsysPort, value);
            }
        }

        private static string UMDUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(idUMDUrl, UMDUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idUMDUrl, value);
            }
        }

        private static int UMDPort
        {
            get
            {
                return AppSettings.GetValueOrDefault(idUMDPort, UMDPortDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idUMDPort, value);
            }
        }
    }
}
