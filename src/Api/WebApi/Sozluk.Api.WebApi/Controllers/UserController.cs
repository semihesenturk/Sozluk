using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Application.Features.Commands.User.ConfirmEmail;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Api.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    #region Variables
    private readonly IMediator _mediator;
    #endregion

    #region Constructor
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var res = await _mediator.Send(command);

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var guid = await _mediator.Send(command);

        return Ok(guid);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        var guid = await _mediator.Send(command);

        return Ok(guid);
    }

    [HttpPost]
    [Route("Confirm")]
    public async Task<IActionResult> ConfirmEmail(Guid id)
    {
        var guid = await _mediator.Send(new ConfirmEmailCommand() { ConfirmationId = id });

        return Ok(guid);
    }

    [HttpPost]
    [Route("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
    {
        var guid = await _mediator.Send(command);

        return Ok(guid);
    }
}

