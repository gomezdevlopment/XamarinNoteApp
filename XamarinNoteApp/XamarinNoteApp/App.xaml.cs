using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNoteApp.Data;

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
            MainPage = new NavigationPage(new MainPage());
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