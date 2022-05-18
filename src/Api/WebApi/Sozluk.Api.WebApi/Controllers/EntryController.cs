using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntryController : ControllerBase
{
    #region Variables
    private readonly IMediator _mediator;

    #endregion

    #region Constructor
    public EntryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    [HttpPost]
    [Route("CreateEntry")]
    public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost]
    [Route("CreateEntryComment")]
    public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
