using Helbiz.Application.Dtos.Auth;

namespace Helbiz.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoginOutputPayload> Login(LoginInputPayload model);
}