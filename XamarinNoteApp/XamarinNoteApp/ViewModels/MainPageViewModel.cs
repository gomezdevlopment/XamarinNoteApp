using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Enum;
using XamarinNoteApp.Models;
using XamarinNoteApp.Services;
using XamarinNoteApp.Views;

namespace XamarinNoteApp.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<int> TestList { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        private NoteRepository noteRepository;

        public MainPageViewModel()
        {
            TestList = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7 };
            Notes = new ObservableCollection<Note>();
            noteRepository = new NoteRepository();
        }

        public ICommand OpenNewNoteScreenCommand => new Command(OpenNewNoteScreen);

        private async void OpenNewNoteScreen()
        {
            Console.WriteLine("Open");
            var newNoteVM = new NewNoteViewModel(noteRepository);
            var newNotePage = new NewNotePage();
            newNotePage.BindingContext = newNoteVM;
            await Application.Current.MainPage.Navigation.PushAsync(newNotePage);
        }
    }
}