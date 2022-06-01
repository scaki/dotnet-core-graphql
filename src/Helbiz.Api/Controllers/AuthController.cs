using Helbiz.Application.Dtos.Auth;
using Helbiz.Application.Features.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Helbiz.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("login")]
    public Task<PostLoginOutputDto> Post(LoginUserCommand request)
    {
        return Mediator.Send(request);
    }
}