using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrivateTaskerAPI.Entity;
using PrivateTaskerAPI.Exceptions;
using PrivateTaskerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly TaskerDb _dbContext;
        private readonly IMapper _mapper;

        public NoteRepository(TaskerDb dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                throw new ApiException("Note not found.");
            }
            _dbContext.Remove(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(NoteDTO noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Note> GetById(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                throw new ApiException("Note not found.");
            }
            return note;
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _dbContext.Notes.Include(n => n.Reminders).ToListAsync(); ;
        }

        public async Task Update(int id, NoteDTO noteDto)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                throw new ApiException("Note not found.");
            }

            note.Title = noteDto.Title;
            note.Content = noteDto.Content;

            await _dbContext.SaveChangesAsync();
        }
    }
}
