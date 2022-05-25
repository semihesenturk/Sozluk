using MediatR;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetUserDetail;

public class GetUserDetailQuery : IRequest<UserDetailViewModel>
{
    #region Constructor
    public GetUserDetailQuery(Guid userId, string userName = null)
    {
        UserId = userId;
        UserName = userName;
    }
    #endregion

    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
