using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.Entry;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.Entry.DeleteVote;
public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
{
    public Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(
            exchangeName: SozlukConstants.VoteExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryVoteQueueName,
            obj: new DeleteEntryVoteEvent()
            {
                EntryId = request.EntryId,
                UserId = request.UserId,
            });

        return Task.FromResult(true);
    }
}
