using PrivateTaskerAPI.Entity;
using PrivateTaskerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrivateTaskerAPI
{
    public class NoteSeeder
    {
        private readonly TaskerDb _dbContext;

        public NoteSeeder(TaskerDb dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Notes.Any())
                {
                    _dbContext.Notes.AddRange(GetNotes());
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Note> GetNotes()
        {
            var notes = new List<Note>()
            {
                new Note
                {
                    Title = "Test title",
                    Content = "Test content",
                    Date = DateTime.Parse("2021-05-05")
                }
            };
            return notes;
        }
    }
}
