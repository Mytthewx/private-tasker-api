using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrivateTaskerAPI.Entity;
using PrivateTaskerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly TaskerDb _dbContext;
        private readonly IMapper _mapper;

        public ReminderRepository(TaskerDb dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var reminder = await _dbContext.Reminders.FirstOrDefaultAsync(x => x.Id == id);
            if (reminder == null)
            {
                return false;
            }
            _dbContext.Remove(reminder);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Reminder> GetById(int id)
        {
            return await _dbContext.Reminders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Reminder>> GetAll()
        {
            return await _dbContext.Reminders.ToListAsync();
        }

        public async Task Create(ReminderDTO reminderDto)
        {
            var reminder = _mapper.Map<Reminder>(reminderDto);
            await _dbContext.Reminders.AddAsync(reminder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(int id, ReminderDTO reminderDto)
        {
            var reminder = await _dbContext.Reminders.FirstOrDefaultAsync(x => x.Id == id);
            if (reminder == null)
            {
                return false;
            }

            reminder.Description = reminderDto.Description;
            reminder.Date = reminderDto.Date;
            reminder.IsDone = reminderDto.IsDone;
            reminder.NoteId = reminderDto.NoteId;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
