using Microsoft.EntityFrameworkCore;
using TodoAPI.Model;

namespace TodoAPI.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } = null;
 //       public DbSet<TodoItemAdd> TodoItemsAdd { get; set; } = null;





    }
}
