using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services
{
    public class UserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetUsersAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await userRepository.GetUserAsync(id);
        }


        public async Task AddUserAsync(User user)
        {
            await userRepository.AddUserAsync(user);
        }


        public async Task UpdateUser(int id, User user)
        {
            await userRepository.PutUserAsync(id, user);
        }


        public async Task DeleteUser(int id)
        {
             await userRepository.DeleteUser(id);
        }
    }
}
