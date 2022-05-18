using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.EntryComment;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.EntryComment.CreateVote;
public class CreateEntryCommentVoteCommandHandler : IRequestHandler<CreateEntryCommentVoteCommand, bool>
{
    public Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(
            exchangeName: SozlukConstants.VoteExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryCommentVoteQueueName,
            obj: new CreateEntryCommentVoteEvent
            {
                EntryCommentId = request.EntryCommentId,
                VoteType = request.VoteType,
                CretedById = request.CretedById
            });

        return Task.FromResult(true);
    }
}
