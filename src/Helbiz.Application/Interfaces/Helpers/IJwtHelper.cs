using Helbiz.Domain.Entities;

namespace Helbiz.Application.Interfaces.Helpers
{
    public interface IJwtHelper
    {
        string GenerateToken(User user);
    }
}