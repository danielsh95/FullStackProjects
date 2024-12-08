using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services
{
    public class TodoService
    {
        private ITodoRepository todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }
        
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await todoRepository.GetTodosAsync();
        }


        public async Task<Todo?> GetTodo(int id)
        {
            return await todoRepository.GetAsync(id);
        }


        public async Task AddTodoAsync(Todo todo)
        {
            await todoRepository.AddTodoAsync(todo);
        }


        public async Task UpdateTodo(int id, Todo todo)
        {
            await todoRepository.PutTodoAsync(id, todo);
        }


        public async Task DeleteTodo(int id)
        {
             await todoRepository.DeleteTodo(id);
        }
    }
}
