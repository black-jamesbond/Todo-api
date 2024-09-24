using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Todo.DbContexts;
using Todo.Entities;
using Todo.Model;

namespace Todo.Services
{
    public class TodoInfoRepository : ITodoInfoRepository
    {
        private TodoItemContext _context;
        private readonly IMapper _mapper;

        public TodoInfoRepository(TodoItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Entities.task?> GetTasksAsync(int id)
        {
            return await _context.Tasks.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<task> AddTodoItemAsync(task todoItem)
        {
            _context.Tasks.Add(todoItem);
            await SaveChangesAsync();
            return todoItem;
        }

        public async Task<ActionResult<TodoItem>> GetTodoItemAsync(int id)
        {
            var item = await _context.Tasks.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<TodoItem>(item);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void DeleteTodoItem(task todoItem)
        {
            _context.Tasks.Remove(todoItem);
        }
    }
}