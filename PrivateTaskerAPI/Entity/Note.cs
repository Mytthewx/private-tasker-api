using System;
using System.Collections.Generic;

namespace PrivateTaskerAPI.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Reminder> Reminders { get; set; }
    }
}
