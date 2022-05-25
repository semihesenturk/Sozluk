using MediatR;
using Microsoft.EntityFrameworkCore;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.SearchBySubject;

public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
{
    #region Variables
    private readonly IEntryRepository _entryRepository;
    #endregion

    #region Constructor
    public SearchEntryQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }
    #endregion

    public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
    {
        var result = _entryRepository
            .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
            .Select(i => new SearchEntryViewModel()
            {
                Id = i.Id,
                Subject = i.Subject
            });

        return await result.ToListAsync(cancellationToken);
    }
}
