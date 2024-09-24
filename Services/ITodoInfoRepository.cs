using Microsoft.AspNetCore.Mvc;
using Todo.DbContexts;
using Todo.Entities;
using Todo.Model;

namespace Todo.Services

{
    public interface ITodoInfoRepository
    {
        Task<Entities.task?> GetTasksAsync(int id);
        Task<task> AddTodoItemAsync(task todoItem);
        Task<ActionResult<TodoItem>> GetTodoItemAsync(int id);
        Task<bool> SaveChangesAsync();
        void DeleteTodoItem(task todoItem);
    }
}
