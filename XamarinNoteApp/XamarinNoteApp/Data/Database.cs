using SQLite;
using System.IO;
using Xamarin.Essentials;
using XamarinNoteApp.Models;

namespace XamarinNoteApp.Data
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _database;

        public Database()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>();
        }
    }
}