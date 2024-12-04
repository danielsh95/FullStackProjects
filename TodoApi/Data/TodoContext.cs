using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext: DbContext
    {
        public DbSet<Todo> todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
            
        }
    }
}
