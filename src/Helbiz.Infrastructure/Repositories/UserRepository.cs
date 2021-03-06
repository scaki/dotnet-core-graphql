using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Entities;
using Helbiz.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Helbiz.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return Context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
        public User? GetUserByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x => x.Username == username);
        }

        public IQueryable<User> GetUsersQueryable()
        {
            return Context.Users.AsQueryable();
        }
    }
}