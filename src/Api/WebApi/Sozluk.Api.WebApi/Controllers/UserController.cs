using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}

