using PrivateTaskerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Services
{
    public interface INoteService
    {
        Task<Note> GetById(int id);
        Task<IEnumerable<Note>> GetAll();
        Task Create(NoteDTO noteDto);
        Task Delete(int id);
        Task Update(int id, NoteDTO noteDto);
    }
}
