using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.Entry;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.Entry.CreateVote;
public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
{
    public Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryVoteQueueName,
            obj: new CreateEntryVoteEvent()
            {
                CreatedById = request.CreatedById,
                EntryId = request.EntryId,
                VoteType = request.VoteType
            });

        return Task.FromResult(true);
    }
}
