﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Application.Features.Queries.GetEntries;
using Sozluk.Application.Features.Queries.GetEntryComments;
using Sozluk.Application.Features.Queries.GetEntryDetail;
using Sozluk.Application.Features.Queries.GetMainPageEntries;
using Sozluk.Application.Features.Queries.GetUserEntries;
using Sozluk.Common.Models.Queries;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntryController : BaseController
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

    #region Operations
    [HttpGet]
    public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQuery query)
    {
        var entries = await _mediator.Send(query);
        return Ok(entries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetEntryDetailQuery(id, UserId));

        return Ok(result);
    }

    [HttpGet]
    [Route("Comments/{id}")]
    public async Task<IActionResult> GetEntryComments(Guid id, int page, int pageSize)
    {
        var result = await _mediator.Send(new GetEntryCommentsQuery(page, pageSize, id, UserId));

        return Ok(result);
    }

    [HttpGet]
    [Route("UserEntries")]
    public async Task<IActionResult> GetUserEntries(string userName, Guid userId, int page, int pageSize)
    {
        if (userId == Guid.Empty && string.IsNullOrEmpty(userName))
            userId = UserId.Value;

        var result = await _mediator.Send(new GetUserEntriesQuery(userId, userName, page, pageSize));

        return Ok(result);
    }

    [HttpGet]
    [Route("MainPageEntries")]
    public async Task<IActionResult> GetMainPageEntries(int page, int pageSize)
    {
        var entries = await _mediator.Send(new GetMainPageEntriesQuery(UserId, page, pageSize));
        return Ok(entries);
    }

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
        if (!command.CreatedById.HasValue)
            command.CreatedById = UserId;

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> Search([FromQuery] SearchEntryQuery query)
    {
        var result = _mediator.Send(query);

        return Ok(result);
    }
    #endregion
}
