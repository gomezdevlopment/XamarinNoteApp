using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
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
            noteRepository = new NoteRepository();
            Notes = new ObservableCollection<Note>();
            GetNotesFromDb();
        }

        public ICommand OpenNewNoteScreenCommand => new Command(OpenNewNoteScreen);

        private async void OpenNewNoteScreen()
        {
            Console.WriteLine("Open");
            var newNoteVM = new NewNoteViewModel(this, null);
            var newNotePage = new NewNotePage();
            newNotePage.BindingContext = newNoteVM;
            await Application.Current.MainPage.Navigation.PushAsync(newNotePage);
        }

        public async void GetNotesFromDb()
        {
            Notes.Clear();
            var notes = await noteRepository.GetNotes();
            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }

        public ICommand OpenNoteCommand => new Command(OpenNote);

        private async void OpenNote(object o)
        {
            Note selectedNote = o as Note;
            if (selectedNote != null)
            {
                var newNoteVM = new NewNoteViewModel(this, selectedNote);
                var newNotePage = new NewNotePage();
                newNotePage.BindingContext = newNoteVM;
                await Application.Current.MainPage.Navigation.PushAsync(newNotePage);
            }
        }
    }
}