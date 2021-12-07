using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateTaskerAPI.Models
{
    public class ReminderDTO
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public int NoteId { get; set; }
    }
}
