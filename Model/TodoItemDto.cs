namespace Todo.Model
{
    internal class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool isCompleted { get; set; } = false;
    }
}