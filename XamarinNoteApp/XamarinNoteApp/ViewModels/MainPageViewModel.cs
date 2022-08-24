using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Models;
using XamarinNoteApp.Services;
using XamarinNoteApp.Views.NewNote;

namespace XamarinNoteApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Note> Notes { get; set; }
        private ObservableCollection<object> _selectedNotes;
        private NoteRepository noteRepository;

        private SelectionMode _selectionMode = SelectionMode.None;

        public SelectionMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                if (_selectionMode != value)
                {
                    _selectionMode = value;
                    OnPropertyChanged(nameof(SelectionMode));
                }
            }
        }

        public ObservableCollection<object> SelectedNotes
        {
            get => _selectedNotes; set
            {
                _selectedNotes = value;
                OnPropertyChanged(nameof(SelectedNotes));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageViewModel()
        {
            noteRepository = new NoteRepository();
            Notes = new ObservableCollection<Note>();
            _selectedNotes = new ObservableCollection<object>();
            TapNoteCommand = new Command<Note>(TapNote);
            LongPressNoteCommand = new Command<Note>(LongPressNote);
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

        public Command<Note> TapNoteCommand { get; set; }

        private async void TapNote(Note selectedNote)
        {
            if (selectedNote != null)
            {
                if (_selectionMode == SelectionMode.None)
                {
                    var newNoteVM = new NewNoteViewModel(this, selectedNote);
                    var newNotePage = new NewNotePage();
                    newNotePage.BindingContext = newNoteVM;
                    await Application.Current.MainPage.Navigation.PushAsync(newNotePage);
                }
            }
        }

        public Command<Note> LongPressNoteCommand { get; set; }

        private void LongPressNote(Note selectedNote)
        {
            if (selectedNote != null)
            {
                if (_selectionMode == SelectionMode.None)
                {
                    SelectionMode = SelectionMode.Multiple;
                    SelectedNotes.Add(selectedNote);
                }
            }
        }
    }
}