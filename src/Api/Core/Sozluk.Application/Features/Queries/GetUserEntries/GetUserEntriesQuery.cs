using MediatR;
using Sozluk.Common.Models.Page;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetUserEntries;

public class GetUserEntriesQuery : BasePagedQuery, IRequest<PagedViewModel<GetUserEntriesDetailViewModel>>
{
    #region Constructor
    public GetUserEntriesQuery(Guid? userId, string userName = null, int page = 1, int pageSize = 10)
        : base(page, pageSize)
    {
        UserId = userId;
        UserName = userName;
    }
    #endregion

    public Guid? UserId { get; set; }
    public string UserName { get; set; }
}
