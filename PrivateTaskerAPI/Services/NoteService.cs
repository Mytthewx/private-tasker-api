using Microsoft.Extensions.Logging;
using NLog;
using PrivateTaskerAPI.Models;
using PrivateTaskerAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository noteRepository, ILogger<NoteService> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }

        public async Task Delete(int id)
        {
            _logger.LogError($"Restaurant with id: {id} DELETE action invoked.");
            await _noteRepository.Delete(id);
        }

        public async Task<Note> GetById(int id)
        {
            return await _noteRepository.GetById(id);
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _noteRepository.GetAll();
        }

        public async Task Create(NoteDTO noteDto)
        {
            await _noteRepository.Add(noteDto);
        }

        public async Task Update(int id, NoteDTO noteDto)
        {
            await _noteRepository.Update(id, noteDto);
        }
    }
}
