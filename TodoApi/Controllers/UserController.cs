using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await userService.AddUserAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task UpdateTodo(int id, User user)
        {
            await userService.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTodo(int id)
        {
            await userService.DeleteUser(id);
        }
    }
}
