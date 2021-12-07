using AutoMapper;
using PrivateTaskerAPI.Models;

namespace PrivateTaskerAPI.Profiles
{
    public class TaskerMappingProfile : Profile
    {
        public TaskerMappingProfile()
        {
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<Reminder, ReminderDTO>().ReverseMap();
        }
    }
}
