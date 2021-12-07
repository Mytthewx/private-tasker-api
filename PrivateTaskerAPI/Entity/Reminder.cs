using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateTaskerAPI.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }

        public int NoteId { get; set; }
    }
}
