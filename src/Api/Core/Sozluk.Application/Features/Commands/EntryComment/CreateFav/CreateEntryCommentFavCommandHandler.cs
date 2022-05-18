using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.EntryComment;
using Sozluk.Common.Infrastructure;

namespace Sozluk.Application.Features.Commands.EntryComment.CreateFav;
public class CreateEntryCommentFavCommandHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
{
    #region Variables

    #endregion
    #region Constructor

    #endregion
    public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
                                           exchangeType: SozlukConstants.DefaultExchangeType,
                                           queueName: SozlukConstants.CreateEntryCommentFavQueueName,
                                           obj: new CreateEntryCommentFavEvent()
                                           {
                                               EntryCommentId = request.EntryCommentId,
                                               CreatedBy = request.UserId
                                           });

        return await Task.FromResult(true);
    }
}
