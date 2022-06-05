using Helbiz.Application.Dtos.User;

namespace Helbiz.Application.Interfaces.Services;

public interface IUserService
{
    Task<RegisterOutputPayload> Register(RegisterInputPayload payload);
}