using MediatR;

namespace Sozluk.Application.Features.Commands.EntryComment.CreateFav;
public class CreateEntryCommentFavCommand : IRequest<bool>
{
    #region Constructor
    public CreateEntryCommentFavCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }
    #endregion

    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}
