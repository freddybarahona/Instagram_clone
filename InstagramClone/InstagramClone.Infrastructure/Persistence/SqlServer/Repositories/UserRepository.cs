using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class UserRepository(InstagramCloneContext context) : IUserRepository
    {
        public async Task<User> Create(User user)
        {
            try
            {
                await context.Users.AddAsync(user);

                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> GetUser(string name)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(x => x.NameUser == name && x.DeletedAt == null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfExist(string name)
        {
            await context.Users.AnyAsync(x => x.NameUser == name);

            return true;
        }

        public IQueryable<User> Queryable()
        {
            try
            {
                return context.Users.Where(x => x.DeletedAt == null).AsQueryable();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
