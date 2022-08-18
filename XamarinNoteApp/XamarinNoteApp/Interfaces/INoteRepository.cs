using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinNoteApp.Models;

namespace XamarinNoteApp.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotes();

        Task<Note> GetNoteById(int id);

        Task CreateNote(string title, string text, int color);

        Task DeleteNote(int id);

        Task EditNote(int id, string title, string text, int color);
    }
}