using System;
using System.IO;
using TheChuck.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheChuck
{
    public partial class App : Application
    {
        static DataBaseService database;

        public static DataBaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favourite.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();
            DependencyService.Register<IApiService, ApiService>();
            DependencyService.Register<INavigationService, Navigationservice>();
            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
