﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinNoteApp.Data;
using XamarinNoteApp.Interfaces;
using XamarinNoteApp.Models;

namespace XamarinNoteApp.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly SQLiteAsyncConnection _database = App.Database;

        public async Task CreateNote(string title, string text, int color)
        {
            var note = new Note
            {
                Title = title,
                Text = text,
                Color = color
            };

            await _database.InsertAsync(note);
        }

        public async Task DeleteNote(int id)
        {
            await _database.DeleteAsync(id);
        }

        public async Task EditNote(int id, string title, string text, int color)
        {
            var note = new Note
            {
                Id = id,
                Title = title,
                Text = text,
                Color = color
            };

            await _database.UpdateAsync(note);
        }

        public async Task<Note> GetNoteById(int id)
        {
            var note = await _database.FindAsync<Note>(id);
            return note;
        }

        public async Task<List<Note>> GetNotes()
        {
            return await _database.Table<Note>().ToListAsync();
        }
    }
}