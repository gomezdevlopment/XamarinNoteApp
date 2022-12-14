using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNoteApp.Data;
using XamarinNoteApp.ViewModels;

namespace XamarinNoteApp
{
    public partial class App : Application
    {
        private static SQLiteAsyncConnection database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database()._database;
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            var mainPageViewModel = new MainPageViewModel();
            MainPage = new NavigationPage(new MainPage(mainPageViewModel));
            MainPage.BindingContext = mainPageViewModel;
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