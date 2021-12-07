using PrivateTaskerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Repositories
{
    public interface INoteRepository
    {
        Task Add(NoteDTO noteDto);
        Task<Note> GetById(int id);
        Task<IEnumerable<Note>> GetAll();
        Task Delete(int id);
        Task Update(int id, NoteDTO noteDto);
    }
}
