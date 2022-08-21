using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Services;
using XamarinNoteApp.Enum;
using XamarinNoteApp.Models;

namespace XamarinNoteApp.ViewModels
{
    public class NewNoteViewModel
    {
        public String NewNoteTitle { get; set; }
        public String NewNoteText { get; set; }
        public int NewNoteColor { get; set; }
        private NoteRepository _noteRepository;
        private MainPageViewModel _mainPageViewModel;
        private Note _note;

        public NewNoteViewModel(MainPageViewModel mainPageViewModel, Note note)
        {
            NewNoteTitle = "Empty Title";
            NewNoteColor = (int)Colors.Yellow;
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
    }
}