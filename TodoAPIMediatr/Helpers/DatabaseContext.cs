using Microsoft.EntityFrameworkCore;
using TodoAPIMediatr.Entity;

namespace TodoAPIMediatr.Helpers
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        // just a name of DB property
        // not the name of the table!!
        public DbSet<TodoItemEntity>? TodoItems { get; set; }


    }
}
