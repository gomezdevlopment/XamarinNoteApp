using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Services;
using XamarinNoteApp.Enum;
using XamarinNoteApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinNoteApp.Converters;
using Xamarin.CommunityToolkit.Extensions;
using XamarinNoteApp.Views.NewNote.Popups;
using System.ComponentModel;

namespace XamarinNoteApp.ViewModels
{
    public class NewNoteViewModel : INotifyPropertyChanged
    {
        private int newNoteColor;
        public String NewNoteTitle { get; set; }
        public String NewNoteText { get; set; }

        public int NewNoteColor
        {
            get => newNoteColor;
            set
            {
                if (newNoteColor != value)
                {
                    newNoteColor = value;
                    OnPropertyChanged(nameof(NewNoteColor));
                }
            }
        }

        private NoteRepository _noteRepository;
        private MainPageViewModel _mainPageViewModel;
        private Note _note;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<int> NoteColors { get; set; }

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
            NewNoteTitle = "Empty Title";

            _noteRepository = new NoteRepository();
            _mainPageViewModel = mainPageViewModel;
            _note = note;

            if (_note != null)
            {
                NewNoteTitle = note.Title;
                NewNoteText = note.Text;
                NewNoteColor = note.Color;
            }
        }

        public ICommand SaveNoteCommand => new Command(SaveNote);

        private async void SaveNote()
        {
            if (NewNoteText != null && _note == null)
            {
                await _noteRepository.CreateNote(NewNoteTitle, NewNoteText, NewNoteColor);
                _mainPageViewModel.GetNotesFromDb();
            }

            if (_note != null)
            {
                await _noteRepository.EditNote(_note.Id, NewNoteTitle, NewNoteText, NewNoteColor);
                _mainPageViewModel.GetNotesFromDb();
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public ICommand OpenMenuCommand => new Command(OpenMenu);

        private void OpenMenu()
        {
            var noteColorSelectionPopup = new NoteColorSelectionPopup();
            noteColorSelectionPopup.BindingContext = this;
            Application.Current.MainPage.Navigation.ShowPopup(noteColorSelectionPopup);
        }

        public ICommand ChangeNoteColorCommand => new Command(ChangeNoteColor);

        private void ChangeNoteColor(object o)
        {
            int color = (int)o;
            NewNoteColor = color;
        }
    }
}