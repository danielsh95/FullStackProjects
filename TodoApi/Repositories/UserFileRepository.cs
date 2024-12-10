using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class UserFileRepository : IUserRepository
    {
        private readonly string _pathFile;

        public UserFileRepository(string pathFile)
        {
            _pathFile = pathFile;
        }

        public async Task AddUserAsync(User user)
        {
            List<User> userList = new List<User>();
            string allContentFromFile = await File.ReadAllTextAsync(_pathFile);
            userList = JsonSerializer.Deserialize<List<User>>(allContentFromFile) ?? new List<User>();

            user.Id = userList.Any()? userList.Max(t => t.Id) + 1 : 1;
            userList.Add(user);

            await File.WriteAllTextAsync(_pathFile, JsonSerializer.Serialize(userList));
        }

        public async Task DeleteUser(int id)
        {
            string UsersString = await File.ReadAllTextAsync(_pathFile);
            var users = JsonSerializer.Deserialize<List<User>>(UsersString) ?? new List<User>();
            var user = users.Find(t => t.Id == id) ?? null;
            if (user != null)
            {
                users.Remove(user);
                UsersString = JsonSerializer.Serialize(users);
                await File.WriteAllTextAsync(_pathFile, UsersString);
            }

        }

        public async Task<User?> GetUserAsync(int id)
        {
            string usersString = await File.ReadAllTextAsync(_pathFile);
            var users = JsonSerializer.Deserialize<List<User>>(usersString) ?? new List<User>();
            var user = users.Find(t => t.Id == id) ?? null;
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            string usersString = await File.ReadAllTextAsync(_pathFile);
            var users = JsonSerializer.Deserialize<List<User>>(usersString) ?? new List<User>();
            return users;
        }

        public async Task PutUserAsync(int id, User user)
        {
            string usersString = await File.ReadAllTextAsync(_pathFile);
            var users = JsonSerializer.Deserialize<List<User>>(usersString) ?? new List<User>();
            var OurUser = users.Find(t => t.Id == id) ?? null;
            if (OurUser != null)
            {
                OurUser.UserName = user.UserName;
                OurUser.Email = user.Email;
                OurUser.Password = user.Password;
                OurUser.todoLists = user.todoLists;
                usersString = JsonSerializer.Serialize(users);
                await File.WriteAllTextAsync(_pathFile, usersString);
            }
        }
    }
}