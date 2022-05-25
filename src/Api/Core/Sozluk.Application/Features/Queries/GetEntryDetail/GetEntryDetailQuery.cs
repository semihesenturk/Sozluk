using MediatR;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetEntryDetail;

public class GetEntryDetailQuery : IRequest<GetEntryDetailViewModel>
{
    #region Constructor
    public GetEntryDetailQuery(Guid entryId, Guid? userId)
    {
        EntryId = entryId;
        UserId = userId;
    }
    #endregion

    public Guid EntryId { get; set; }
    public Guid? UserId { get; set; }
}
