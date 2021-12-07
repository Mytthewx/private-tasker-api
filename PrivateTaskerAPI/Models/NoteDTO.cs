using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateTaskerAPI.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public List<ReminderDTO> Reminders { get; set; }
    }
}
