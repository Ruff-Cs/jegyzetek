using jegyzetek.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jegyzetek.Database
{
    public static class NoteDatabase
    {
        static SQLiteAsyncConnection Database;
        static async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = Database.CreateTableAsync<Note>();
        }

        public static List<Note> GetAllNotesAsync()
        {
            Init();
            if (Database is not null)
                return Database.Table<Note>().ToListAsync().Result;
            return null;
        }

        public static Note GetNoteAsync(int id)
        {
            Init();
            if (Database is not null)
                return Database.Table<Note>().Where(x => x.Id == id).FirstOrDefaultAsync().Result;
            return null;
        }

        public static async Task<int?> SaveNoteAsync(Note note)
        {
            Init();
            if (Database is not null)
            {
                if (note.Id == 0) return await Database.InsertAsync(note);
                else return await Database.UpdateAsync(note);
            }
            return null;
        }

        public static async Task<int?> DeleteNoteAsync(Note note)
        {
            Init();
            if (Database is not null)
                return await Database.DeleteAsync(note);
            return null;
        }
    }
}
