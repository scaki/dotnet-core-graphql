using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Entities;
using Helbiz.Infrastructure.Context;

namespace Helbiz.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}