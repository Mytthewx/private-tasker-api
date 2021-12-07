using PrivateTaskerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Services
{
    public interface IReminderService
    {
        Task Create(ReminderDTO reminderDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<Reminder>> GetAll();
        Task<Reminder> GetById(int id);
        Task<bool> Update(int id, ReminderDTO reminderDto);
    }
}