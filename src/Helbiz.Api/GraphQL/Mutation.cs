using Helbiz.Application.Dtos.Auth;
using Helbiz.Application.Dtos.User;
using Helbiz.Application.Interfaces.Services;

namespace Helbiz.Api.GraphQL;

public class Mutation
{
    public async Task<LoginOutputPayload> Login([Service] IAuthService _authService, LoginInputPayload payload)
    {
        return await _authService.Login(payload);
    }

    public async Task<RegisterOutputPayload> Register([Service] IUserService _userService, RegisterInputPayload payload)
    {
        return await _userService.Register(payload);
    }
}