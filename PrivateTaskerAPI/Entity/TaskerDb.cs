using Microsoft.EntityFrameworkCore;
using PrivateTaskerAPI.Models;

namespace PrivateTaskerAPI.Entity
{
    public class TaskerDb : DbContext
    {
        public TaskerDb(DbContextOptions<TaskerDb> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Reminder>()
                .Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Reminder>()
                .Property(r => r.Date)
                .IsRequired();
        }
    }
}
