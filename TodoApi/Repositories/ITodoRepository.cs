using System.Collections;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo?> GetAsync(int id);
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task AddTodoAsync(Todo todo);

        Task PutTodoAsync(int id, Todo todo);

        Task DeleteTodo(int id);

    }
}
