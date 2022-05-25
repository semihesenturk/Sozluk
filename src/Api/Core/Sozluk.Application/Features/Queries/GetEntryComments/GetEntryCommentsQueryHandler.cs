using MediatR;
using Microsoft.EntityFrameworkCore;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure.Extensions;
using Sozluk.Common.Models.Page;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetEntryComments;

public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQuery, PagedViewModel<GetEntryCommentsViewModel>>
{
    #region Variables
    private readonly IEntryCommentRepository _entryCommentRepository;
    #endregion
    #region Constructor
    public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository)
    {
        _entryCommentRepository = entryCommentRepository;
    }
    #endregion
    public async Task<PagedViewModel<GetEntryCommentsViewModel>> Handle(GetEntryCommentsQuery request, CancellationToken cancellationToken)
    {
        var query = _entryCommentRepository.AsQueryable();

        query = query.Include(i => i.EntryCommentFavorites)
                     .Include(i => i.CreatedUser)
                     .Include(i => i.EntryCommentVotes)
                     .Where(i => i.EntryId == request.EntryId);

        var list = query.Select(i => new GetEntryCommentsViewModel()
        {
            Id = i.Id,
            Content = i.Content,
            IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites.Any(j => j.CreatedById == request.UserId),
            FavoritedCount = i.EntryCommentFavorites.Count,
            CreatedDate = i.CreateDate,
            CreatedByUserName = i.CreatedUser.UserName,
            VoteType =
            request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreatedById == request.UserId)
                            ? i.EntryCommentVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType
                            : Common.ViewModels.VoteType.None
        });

        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}
