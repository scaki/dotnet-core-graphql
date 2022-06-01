using Helbiz.Domain.Entities;

namespace Helbiz.Application.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}