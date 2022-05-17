using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common;
using Sozluk.Common.Events.User;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.User.Update;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    #region Variables
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    #endregion

    #region Constructor
    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    #endregion

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetByIdAsync(request.Id);

        if (dbUser is null)
            throw new DatabaseValidationException("User not found!");

        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;
        dbUser = _mapper.Map(request, dbUser);


        var rows = await _userRepository.UpdateAsync(dbUser);

        //Check if email changed
        if (emailChanged && rows > 0)
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

            dbUser.EmailConfirmed = false;
            await _userRepository.UpdateAsync(dbUser);
        }

        return dbUser.Id;
    }
}
