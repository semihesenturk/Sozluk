using MediatR;
using Sozluk.Common.ViewModels;

namespace Sozluk.Common.Models.RequestModels;
public class CreateEntryCommentVoteCommand : IRequest<bool>
{
    #region Constructor
    public CreateEntryCommentVoteCommand()
    {
    }
    public CreateEntryCommentVoteCommand(Guid entryCommentId, VoteType voteType, Guid cretedById)
    {
        EntryCommentId = entryCommentId;
        VoteType = voteType;
        CretedById = cretedById;
    }
    #endregion

    public Guid EntryCommentId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CretedById { get; set; }
}

