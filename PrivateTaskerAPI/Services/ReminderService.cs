using PrivateTaskerAPI.Models;
using PrivateTaskerAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _reminderRepository.Delete(id);
        }

        public async Task<Reminder> GetById(int id)
        {
            return await _reminderRepository.GetById(id);
        }

        public async Task<IEnumerable<Reminder>> GetAll()
        {
            return await _reminderRepository.GetAll();
        }

        public async Task Create(ReminderDTO reminderDto)
        {
            await _reminderRepository.Create(reminderDto);
        }

        public async Task<bool> Update(int id, ReminderDTO reminderDto)
        {
            return await _reminderRepository.Update(id, reminderDto);
        }
    }
}
