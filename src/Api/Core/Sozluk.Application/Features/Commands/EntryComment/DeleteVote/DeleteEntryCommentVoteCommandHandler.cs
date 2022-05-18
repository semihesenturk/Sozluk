using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.EntryComment;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.EntryComment.DeleteVote;

public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
{
    public Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(
            exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryCommentVoteQueueName,
            obj: new DeleteEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreatedUser = request.CreatedUser
            });

        return Task.FromResult(true);
    }
}