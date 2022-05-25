using MediatR;
using Microsoft.EntityFrameworkCore;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure.Extensions;
using Sozluk.Common.Models.Page;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetUserEntries;

public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQuery, PagedViewModel<GetUserEntriesDetailViewModel>>
{
    #region Variables
    private readonly IEntryRepository _entryRepository;
    #endregion

    #region Constructor
    public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    #endregion
    public async Task<PagedViewModel<GetUserEntriesDetailViewModel>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();

        if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
        {
            query = query.Where(i => i.CreatedById == request.UserId);
        }
        else if (!string.IsNullOrEmpty(request.UserName))
        {
            query = query.Where(i => i.CreatedUser.UserName == request.UserName);
        }
        else 
            return null;

        query = query.Include(i => i.EntryFavorites)
                     .Include(i => i.CreatedUser);

        var list = query.Select(i => new GetUserEntriesDetailViewModel()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = false,
            FavoritedCount = i.EntryFavorites.Count,
            CreatedDate = i.CreateDate,
            CreatedByUserName = i.CreatedUser.UserName
        });

        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}
