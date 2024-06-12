using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jegyzetek.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20), NotNull]
        public string Title { get; set; }
        [MaxLength(150), NotNull]
        public string Text { get; set; }
        [MaxLength(20), NotNull]
        public string Category { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
    }
}
