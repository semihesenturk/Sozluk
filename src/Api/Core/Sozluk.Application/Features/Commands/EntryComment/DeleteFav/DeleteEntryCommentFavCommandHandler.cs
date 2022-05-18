using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.EntryComment;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.EntryComment.DeleteFav;
public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavCommand, bool>
{
    public Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(
            exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryCommentFavQueueName,
            obj: new DeleteEntryCommentFavEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreatedById = request.CreatedById,
            });

        return Task.FromResult(true);
    }
}
