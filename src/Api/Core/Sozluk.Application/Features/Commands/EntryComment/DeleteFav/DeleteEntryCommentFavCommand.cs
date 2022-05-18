using MediatR;

namespace Sozluk.Application.Features.Commands.EntryComment.DeleteFav;
public class DeleteEntryCommentFavCommand : IRequest<bool>
{
    #region Constructor
    public DeleteEntryCommentFavCommand(Guid entryCommentId, Guid createdById)
    {
        EntryCommentId = entryCommentId;
        CreatedById = createdById;
    }
    #endregion

    public Guid EntryCommentId { get; set; }
    public Guid CreatedById { get; set; }
}
