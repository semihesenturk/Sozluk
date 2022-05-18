using MediatR;

namespace Sozluk.Application.Features.Commands.Entry.DeleteVote;
public class DeleteEntryVoteCommand : IRequest<bool>
{
    #region Constructor
    public DeleteEntryVoteCommand(Guid entryId, Guid userId)
    {
        EntryId = entryId;
        UserId = userId;
    }
    #endregion

    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}
