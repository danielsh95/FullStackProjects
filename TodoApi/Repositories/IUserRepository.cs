using System.Collections;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User todo);
        Task PutUserAsync(int id, User user);
        Task DeleteUser(int id);
    }
}
