using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.Queries;

namespace Sozluk.Application.Features.Queries.GetUserDetail;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
{
    #region Variables
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        Api.Domain.Models.User dbUser = null;

        if (request.UserId != Guid.Empty)
            dbUser = await _userRepository.GetByIdAsync(request.UserId);
        else if (!string.IsNullOrEmpty(request.UserName))
            dbUser = await _userRepository.GetSingleAsync(i => i.UserName == request.UserName);

        return _mapper.Map<UserDetailViewModel>(dbUser);
    }
}
