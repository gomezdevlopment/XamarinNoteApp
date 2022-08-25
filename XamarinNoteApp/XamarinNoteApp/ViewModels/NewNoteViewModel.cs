using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Services;
using XamarinNoteApp.Enum;
using XamarinNoteApp.Models;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Extensions;
using XamarinNoteApp.Views.NewNote.Popups;
using System.ComponentModel;

namespace XamarinNoteApp.ViewModels
{
    public class NewNoteViewModel : INotifyPropertyChanged
    {
        public ICommand SaveNoteCommand => new Command(SaveNote);
        public ICommand OpenMenuCommand => new Command(OpenMenu);
        public ICommand ChangeNoteColorCommand => new Command(ChangeNoteColor);

        public String NewNoteTitle { get; set; }
        public String NewNoteText { get; set; }
        public String NewNoteDate { get; set; }
        public ObservableCollection<int> NoteColors { get; set; }

        private NoteRepository _noteRepository;
        private MainPageViewModel _mainPageViewModel;
        private Note _note;

        private int _newNoteColor;

        public int NewNoteColor
        {
            get => _newNoteColor;
            set
            {
                if (_newNoteColor != value)
                {
                    _newNoteColor = value;
                    OnPropertyChanged(nameof(NewNoteColor));
                }
            }
        }

        public NewNoteViewModel(MainPageViewModel mainPageViewModel, Note note)
        {
            NewNoteColor = (int)Colors.Yellow;
            NoteColors = new ObservableCollection<int> {
                ((int)Colors.Yellow),
                ((int)Colors.Green),
                ((int)Colors.Blue),
                ((int)Colors.Purple),
                ((int)Colors.Pink),
                ((int)Colors.Red),
                ((int)Colors.Orange),
            };
            NewNoteTitle = "";
            NewNoteDate = DateTime.Now.ToString();
            _noteRepository = new NoteRepository();
            _mainPageViewModel = mainPageViewModel;
            _note = note;

            if (_note != null)
            {
                NewNoteTitle = note.Title;
                NewNoteText = note.Text;
                NewNoteDate = note.Date;
                NewNoteColor = note.Color;
            }
        }

        private async void SaveNote()
        {
            if (NewNoteText != null && _note == null)
            {
                await _noteRepository.CreateNote(NewNoteTitle, NewNoteText, NewNoteDate, NewNoteColor);
                _mainPageViewModel.GetNotesFromDb();
            }

            if (_note != null)
            {
                await _noteRepository.EditNote(_note.Id, NewNoteTitle, NewNoteText, NewNoteDate, NewNoteColor);
                _mainPageViewModel.GetNotesFromDb();
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OpenMenu()
        {
            var today = DateTime.Now.ToString();
            Console.WriteLine(today);
            var noteColorSelectionPopup = new NoteColorSelectionPopup();
            noteColorSelectionPopup.BindingContext = this;
            Application.Current.MainPage.Navigation.ShowPopup(noteColorSelectionPopup);
        }

        private void ChangeNoteColor(object o)
        {
            int color = (int)o;
            NewNoteColor = color;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}