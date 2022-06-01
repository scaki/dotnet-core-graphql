using Helbiz.Application.Dtos.Auth;
using Helbiz.Application.Interfaces.Helpers;
using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Entities;
using MediatR;

namespace Helbiz.Application.Features.Commands
{
    public class LoginUserCommand : IRequest<PostLoginOutputDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, PostLoginOutputDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IJwtHelper _jwtHelper;

            public LoginUserCommandHandler(IUnitOfWork unitOfWork, IJwtHelper jwtHelper)
            {
                _unitOfWork = unitOfWork;
                _jwtHelper = jwtHelper;
            }

            public async Task<PostLoginOutputDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.User.GetUserByUsernameAsync(request.Username);
                var result = new PostLoginOutputDto();
                if (user == null) return result;
                var verifiedPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                if (verifiedPassword)
                {
                    result.Access_token = _jwtHelper.GenerateToken(user);
                }

                return result;
            }
        }
    }
}