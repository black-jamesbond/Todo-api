using AutoMapper;
using Todo.Entities;

namespace Todo.Profiles
{
    public class TodoProfile: Profile
    {
        public TodoProfile()
        {
            CreateMap<task, Model.TodoItem>();
            CreateMap<Model.TodoItem, task>();
        }
    }
}
