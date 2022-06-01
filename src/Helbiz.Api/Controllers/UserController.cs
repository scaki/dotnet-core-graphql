using Helbiz.Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helbiz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    [HttpPost]
    public Task<Unit> Post(RegisterUserCommand request)
    {
        return Mediator.Send(request);
    }
}