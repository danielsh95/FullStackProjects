using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await context.users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.users.ToListAsync();
        }

        public async Task PutUserAsync(int id, User user)
        {
            var existingUser = await context.users.FindAsync(id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.todoLists = user.todoLists;

            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await context.users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Error, the id not exist");
            }
            context.users.Remove(user);

            await context.SaveChangesAsync();
        }
    }
}
