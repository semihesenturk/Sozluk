using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Application.Features.Commands.Entry.DeleteVote;
using Sozluk.Application.Features.Commands.EntryComment.DeleteVote;
using Sozluk.Common.Models.RequestModels;
using Sozluk.Common.ViewModels;

namespace Sozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoteController : BaseController
{
    #region Variables
    private readonly IMediator _mediator;
    #endregion

    #region Constructor
    public VoteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    #region Operations
    [HttpPost]
    [Route("Entry/{entryId}")]
    public async Task<IActionResult> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
    {
        var result = await _mediator.Send(new CreateEntryVoteCommand(entryId, voteType, UserId.Value));

        return Ok(result);
    }

    [HttpPost]
    [Route("EntryComment/{entryCommentId}")]
    public async Task<IActionResult> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
    {
        var result = await _mediator.Send(new CreateEntryCommentVoteCommand(entryCommentId, voteType, UserId.Value));

        return Ok(result);
    }

    [HttpPost]
    [Route("DeleteEntryVote/{entryId}")]
    public async Task<IActionResult> DeleteEntryVote(Guid entryId)
    {
        await _mediator.Send(new DeleteEntryVoteCommand(entryId, UserId.Value));

        return Ok();
    }

    [HttpPost]
    [Route("DeleteEntryCommentVote/{entryId}")]
    public async Task<IActionResult> DeleteEntryCommentVote(Guid entryCommentId)
    {
        await _mediator.Send(new DeleteEntryCommentVoteCommand(entryCommentId, UserId.Value));

        return Ok();
    }
    #endregion
}
