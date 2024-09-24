using Todo.Model;
namespace Todo
{
    public class TodoBase
    {
        public List<TodoItem> Item { get; set; }

        public static TodoBase Instance { get; set; } = new TodoBase();

        public TodoBase()
        {
            Item = new List<TodoItem>()
            {
                new TodoItem()
                {
                    Id = 1,
                    Title = "Wash the dishes",
                    IsCompleted = false
                },
                new TodoItem()
                {
                    Id=2,
                    Title = "sweep your room",
                    IsCompleted = false
                },
                new TodoItem()
                {
                    Id = 3,
                    Title = "go buy gas",
                    IsCompleted = false
                }
                
            };
        }
    }
}
