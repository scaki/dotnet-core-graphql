using Helbiz.Application.Dtos.Auth;

namespace Helbiz.Application.Interfaces.Services;

public interface IAuthService
{
    Task<PostLoginOutputPayload> Login(PostLoginInputPayload model);
}