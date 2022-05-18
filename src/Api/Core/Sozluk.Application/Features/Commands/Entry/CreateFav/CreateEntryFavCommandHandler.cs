using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.Entry;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.Entry.CreateFav;
public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
{
    #region Variables

    #endregion
    #region Constructor

    #endregion
    public Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryFavQueueName,
            obj: new CreateEntryFavEvent()
            {
                EntryId = request.EntryId.Value,
                CreatedById = request.UserId.Value
            });

        return Task.FromResult(true);
    }
}
