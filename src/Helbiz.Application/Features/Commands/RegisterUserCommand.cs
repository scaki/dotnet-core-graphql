using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Entities;
using MediatR;

namespace Helbiz.Application.Features.Commands
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;

            public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Username = request.Username,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };
                _unitOfWork.User.Insert(user);
                _unitOfWork.Save();
                return Task.FromResult(Unit.Value);
            }
        }
    }
}