using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNoteApp.ViewModels;

namespace XamarinNoteApp
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _mainPageViewModel = mainPageViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_mainPageViewModel.MultiSelectEnabled)
                _mainPageViewModel.ShowOrHideToolbar();

            return true;
        }
    }
}