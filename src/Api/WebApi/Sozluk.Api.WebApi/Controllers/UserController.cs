using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Application.Features.Commands.User.ConfirmEmail;
using Sozluk.Application.Features.Queries.GetUserDetail;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Api.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
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

    #region Operations
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _mediator.Send(new GetUserDetailQuery(id));

        return Ok(user);
    }

    [HttpGet]
    [Route("UserName/{userName}")]
    public async Task<IActionResult> GetByUserName(string userName)
    {
        var user = _mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));

        return Ok(user);
    }

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
    #endregion
}

