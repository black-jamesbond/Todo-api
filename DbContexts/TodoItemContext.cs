using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo.DbContexts
{
    public class TodoItemContext : DbContext
    {
    
        public TodoItemContext(DbContextOptions options) : base(options) { }    
        public DbSet<task> Tasks { get; set; }

     
    }
}
