using MediatR;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetEntries;

public class GetEntriesQuery : IRequest<List<GetEntriesviewModel>>
{
    public bool TodaysEntries { get; set; }
    public int Count { get; set; } = 100;
}
