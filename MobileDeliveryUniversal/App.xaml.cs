using MobileDeliveryLogger;
using MobileDeliveryUniversal.Pages;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileDeliveryUniversal
{
    public partial class App : Application
    {
        Logger logger = new Logger("MobileDeliveryUniversal",
            ApplicationData.Current.LocalFolder.Path);

        //[assembly: Dependency(typeof(TestUWPFilePicker.UWP.FilePicker))]
        public App()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //storageFolder.Path;
            
            base.OnStart();
            InitializeComponent();
            //Windows.Storage.AccessCache
                //StorageItemAccessList lst;
           // int cnt = lst.Entries.Count;
            //StorageFile.CreateStreamedFileAsync()
            Logger.Info("App  ::  Launching MainPage.");
            //MainPage = new NavigationPage(new MainPage());]
            MainPage = new MainPage();
        }

        private readonly Func<Stream, string, Task<bool>> saveSignatureDelegate;

        public App(Func<Stream, string, Task<bool>> saveSignature)
        {
            InitializeComponent();

            saveSignatureDelegate = saveSignature;

            MainPage = new NavigationPage(new MainPage());
        }

        public static Task<bool> SaveSignature(Stream bitmap, string filename)
        {
            return ((App)Application.Current).saveSignatureDelegate(bitmap, filename);
        }

        protected override void OnStart()
        {
            
            // Handle when your app starts
            //MainPage = new Trucks();//
            // MainPage = new NavigationPage(view);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
