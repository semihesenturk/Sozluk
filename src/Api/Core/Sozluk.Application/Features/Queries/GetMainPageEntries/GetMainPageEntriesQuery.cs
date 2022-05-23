using AutoMapper;
using MediatR;
using Sozluk.Common.Models.Page;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetMainPageEntries;

public class GetMainPageEntriesQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryDetailViewModel>>
{
    #region Constructor
    public GetMainPageEntriesQuery(Guid? userId, int page, int pageSize) : base(page, pageSize)
    {
        UserId = userId;
    }
    #endregion

    public Guid? UserId { get; set; }

}
