using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;
using Todo.Services;
using AutoMapper;
using Todo.Entities;
using Todo.Profiles;
using Microsoft.EntityFrameworkCore;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoInfoRepository _todoInfoRepository;
        private readonly IMapper _mapper;

        public TodoController(ITodoInfoRepository todoInfoRepository, IMapper mapper)
        {
            _todoInfoRepository = todoInfoRepository ?? throw new ArgumentNullException(nameof(todoInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var tasks = await _todoInfoRepository.GetTasksAsync(id);
            return base.Ok(_mapper.Map<TodoItem>(tasks));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _todoInfoRepository.GetTasksAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return _mapper.Map<TodoItem>(todoItem);
        }

        [HttpPost("AddTodo")]
        public async Task<ActionResult<task>> AddTodoItem(string title)
        {
            var todoItem = new task
            {
                Title = title,
                IsCompleted = false
            };

            await _todoInfoRepository.AddTodoItemAsync(todoItem);
            await _todoInfoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var tasks = await _todoInfoRepository.GetTasksAsync(id);


            if (tasks == null)
            {
                return NotFound();
            }

            _todoInfoRepository.DeleteTodoItem(tasks);
            await _todoInfoRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTodoItem(int id, bool isCompleted)
        {
            var tasks = await _todoInfoRepository.GetTasksAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // Update the IsCompleted status
            var item = _mapper.Map<TodoItem>(tasks);

            item.IsCompleted = isCompleted;

            tasks = _mapper.Map<task>(item);
            // Save changes
            await _todoInfoRepository.SaveChangesAsync();

            return NoContent();
        }



    }
}
