using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoteApp.Services;
using XamarinNoteApp.Enum;

namespace XamarinNoteApp.ViewModels
{
    public class NewNoteViewModel
    {
        private String NewNoteTitle { get; set; }
        private String NewNoteText { get; set; }
        private NoteRepository _noteRepository;

        public NewNoteViewModel(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public ICommand SaveNoteCommand => new Command(SaveNote);

        private async void SaveNote()
        {
            Console.WriteLine(NewNoteText);
            await _noteRepository.CreateNote(NewNoteTitle, NewNoteText, (int)Colors.Yellow);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}