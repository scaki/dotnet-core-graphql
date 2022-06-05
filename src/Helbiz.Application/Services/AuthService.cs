using Helbiz.Application.Dtos.Auth;
using Helbiz.Application.Interfaces.Helpers;
using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Application.Interfaces.Services;

namespace Helbiz.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHelper _jwtHelper;

    public AuthService(IUnitOfWork unitOfWork, IJwtHelper jwtHelper)
    {
        _unitOfWork = unitOfWork;
        _jwtHelper = jwtHelper;
    }

    public async Task<LoginOutputPayload> Login(LoginInputPayload model)
    {
        var user = await _unitOfWork.User.GetUserByUsernameAsync(model.Username);
        var result = new LoginOutputPayload();
        if (user == null) return result;
        var verifiedPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
        if (verifiedPassword)
        {
            result.Access_token = _jwtHelper.GenerateToken(user);
        }

        return result;
    }
}