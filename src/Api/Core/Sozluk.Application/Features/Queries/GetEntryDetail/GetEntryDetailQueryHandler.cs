using MediatR;
using Microsoft.EntityFrameworkCore;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetEntryDetail;

public class GetEntryDetailQueryHandler : IRequestHandler<GetEntryDetailQuery, GetEntryDetailViewModel>
{
    #region Variables
    private readonly IEntryRepository _entryRepository;
    #endregion

    #region Constructor
    public GetEntryDetailQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }
    #endregion

    public async Task<GetEntryDetailViewModel> Handle(GetEntryDetailQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();

        query = query.Include(i => i.EntryFavorites)
                     .Include(i => i.CreatedUser)
                     .Include(i => i.EntryVotes)
                     .Where(i => i.Id == request.EntryId);

        var list = query.Select(i => new GetEntryDetailViewModel()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = request.UserId.HasValue && i.EntryFavorites.Any(j => j.CreatedById == request.UserId),
            FavoritedCount = i.EntryFavorites.Count,
            CreatedDate = i.CreateDate,
            CretedByUserName = i.CreatedUser.UserName,
            VoteType = request.UserId.HasValue && i.EntryVotes.Any(j => j.CreatedById == request.UserId)
            ? i.EntryVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType
            : Common.ViewModels.VoteType.None
        });

        return await list.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
