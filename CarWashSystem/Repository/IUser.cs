using CarWashSystem.Models;

namespace CarWashSystem.Repository
{
    public interface IUser
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id,User user);
        Task<User> DeleteUser(int id);
    }
}
