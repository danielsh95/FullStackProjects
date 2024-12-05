using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        TodoService todoService;
        public TodoController(TodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            return Ok(await todoService.GetAllTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var todo = await todoService.GetTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            await todoService.AddTodoAsync(todo);

            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id}, todo);
        }

        [HttpPut("{id}")]
        public async Task UpdateTodo(int id, Todo todo)
        {
            await todoService.UpdateTodo(id, todo);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTodo(int id)
        {
            await todoService.DeleteTodo(id);
        }
    }
}
