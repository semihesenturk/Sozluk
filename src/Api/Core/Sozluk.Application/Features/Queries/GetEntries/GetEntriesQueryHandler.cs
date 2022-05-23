using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetEntries;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesviewModel>>
{
    #region Variables
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }
    #endregion
    public async Task<List<GetEntriesviewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();

        if (request.TodaysEntries)
        {
            query = query
                .Where(i => i.CreateDate == DateTime.Now.Date)
                .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);
        }

        query = query.Include(i => i.EntryComments)
             .OrderBy(i => Guid.NewGuid())
             .Take(request.Count);

        return await query.ProjectTo<GetEntriesviewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
