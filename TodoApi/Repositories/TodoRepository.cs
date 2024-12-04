using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext context;

        public TodoRepository(TodoContext context)
        {
            this.context = context;
        }

        public async Task AddTodoAsync(Todo todo)
        {
            await context.AddAsync(todo);
            await context.SaveChangesAsync();
        }

        public async Task<Todo?> GetAsync(int id)
        {
            return await context.todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await context.todos.ToListAsync();
        }

        public async Task PutTodoAsync(int id, Todo todo)
        {
            var existingTodo = await context.todos.FindAsync(id);

            if (existingTodo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {id} not found.");
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;

            await context.SaveChangesAsync();
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await context.todos.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException("Error, the id not exist");
            }
            context.todos.Remove(todo);

            await context.SaveChangesAsync();
        }
    }
}
