using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinNoteApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Text { get; set; }
        public int Color { get; set; }
    }
}