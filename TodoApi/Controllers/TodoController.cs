using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        ITodoRepository todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            return Ok(await todoRepository.GetTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var todo = await todoRepository.GetAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            await todoRepository.AddTodoAsync(todo);

            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id}, todo);
        }

        [HttpPut("{id}")]
        public async Task UpdateTodo(int id, Todo todo)
        {
            await todoRepository.PutTodoAsync(id, todo);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTodo(int id)
        {
            await todoRepository.DeleteTodo(id);
        }
    }
}
