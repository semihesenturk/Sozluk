using MediatR;

namespace Sozluk.Application.Features.Commands.EntryComment.DeleteVote;

public class DeleteEntryCommentVoteCommand : IRequest<bool>
{
    #region Constructor
    public DeleteEntryCommentVoteCommand()
    {
    }
    public DeleteEntryCommentVoteCommand(Guid entryCommentId, Guid createdUser)
    {
        EntryCommentId = entryCommentId;
        CreatedUser = createdUser;
    }
    #endregion

    public Guid EntryCommentId { get; set; }
    public Guid CreatedUser { get; set; }
}
