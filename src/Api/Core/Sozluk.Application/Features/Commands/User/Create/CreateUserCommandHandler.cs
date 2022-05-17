using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common;
using Sozluk.Common.Events.User;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.User.Create;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    #region Variables
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    #endregion

    #region Constructor
    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    #endregion
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existsUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (existsUser is not null)
        { throw new DatabaseValidationException("User already exists!"); }

        var dbUser = _mapper.Map<Api.Domain.Models.User>(request);

        var rows = await _userRepository.AddAsync(dbUser);

        //Email changed/created
        if (rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.EmailAddress
            };

            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserEmailExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.UserEmailChangedQueueName,
                                               obj: @event);
        }

        return dbUser.Id;
    }
}
