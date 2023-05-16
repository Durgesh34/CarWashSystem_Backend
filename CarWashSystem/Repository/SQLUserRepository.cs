using CarWashSystem.Data;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class SQLUserRepository : IUser
    {
        private readonly OnDemandDbContext context;

        public SQLUserRepository(OnDemandDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }



        public async Task<List<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingdata = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            existingdata.FullName = user.FullName;
            existingdata.Email = user.Email;
            existingdata.Password = user.Password;
            existingdata.Address = user.Password;

            await context.SaveChangesAsync();
            return existingdata;
        }
        public async Task<User> DeleteUser(int id)
        {
            var user=await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
