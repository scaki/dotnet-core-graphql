using Helbiz.Application.Dtos.User;
using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Application.Interfaces.Services;
using Helbiz.Domain.Entities;
using Mapster;

namespace Helbiz.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<RegisterOutputPayload> Register(RegisterInputPayload payload)
    {
        var user = new User
        {
            Firstname = payload.Firstname,
            Lastname = payload.Lastname,
            Username = payload.Username,
            Email = payload.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(payload.Password)
        };
        _unitOfWork.User.Insert(user);
        _unitOfWork.Save();
        return Task.FromResult(user.Adapt<RegisterOutputPayload>());
    }
}