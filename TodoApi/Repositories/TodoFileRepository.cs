using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoFileRepository : ITodoRepository
    {
        private readonly string _pathFile;

        public TodoFileRepository(string pathFile)
        {
            _pathFile = pathFile;
        }

        public async Task AddTodoAsync(Todo todo)
        {
            List<Todo> todoList = new List<Todo>();
            string allContentFromFile = await File.ReadAllTextAsync(_pathFile);
            todoList = JsonSerializer.Deserialize<List<Todo>>(allContentFromFile) ?? new List<Todo>();

            todo.Id = todoList.Any()? todoList.Max(t => t.Id) + 1 : 1;
            todoList.Add(todo);

            await File.WriteAllTextAsync(_pathFile, JsonSerializer.Serialize(todoList));
        }

        public async Task DeleteTodo(int id)
        {
            string todosString = await File.ReadAllTextAsync(_pathFile);
            var todos = JsonSerializer.Deserialize<List<Todo>>(todosString) ?? new List<Todo>();
            var todo = todos.Find(t => t.Id == id) ?? null;
            if (todo != null)
            {
                todos.Remove(todo);
                todosString = JsonSerializer.Serialize(todos);
                await File.WriteAllTextAsync(_pathFile, todosString);
            }

        }

        public async Task<Todo?> GetAsync(int id)
        {
            string todosString = await File.ReadAllTextAsync(_pathFile);
            var todos = JsonSerializer.Deserialize<List<Todo>>(todosString) ?? new List<Todo>();
            var todo = todos.Find(t => t.Id == id) ?? null;
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            string todosString = await File.ReadAllTextAsync(_pathFile);
            var todos = JsonSerializer.Deserialize<List<Todo>>(todosString) ?? new List<Todo>();
            return todos;
        }

        public async Task PutTodoAsync(int id, Todo todo)
        {
            string todosString = await File.ReadAllTextAsync(_pathFile);
            var todos = JsonSerializer.Deserialize<List<Todo>>(todosString) ?? new List<Todo>();
            var OurTodo = todos.Find(t => t.Id == id) ?? null;
            if (OurTodo != null)
            {
                OurTodo.Title = todo.Title;
                OurTodo.Description = todo.Description;
                todosString = JsonSerializer.Serialize(todos);
                await File.WriteAllTextAsync(_pathFile, todosString);
            }
        }
    }
}