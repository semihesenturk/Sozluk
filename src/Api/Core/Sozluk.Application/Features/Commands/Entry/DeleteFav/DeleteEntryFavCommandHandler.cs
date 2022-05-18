using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.Entry;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.Entry.DeleteFav;
public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
{
    public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(
            exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryFavQueeueName,
            obj: new DeleteEntryFavEvent()
            {
                EntryId = request.EntryId,
                CreatedBy = request.UserId
            });

        return await Task.FromResult(true);
    }
}
