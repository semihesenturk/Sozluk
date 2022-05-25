using MediatR;
using Sozluk.Common.ViewModels;

namespace Sozluk.Common.Models.RequestModels;
public class CreateEntryVoteCommand : IRequest<bool>
{
    #region Constructor
    public CreateEntryVoteCommand(Guid entryId, VoteType voteType, Guid createdById)
    {
        EntryId = entryId;
        VoteType = voteType;
        CreatedById = createdById;
    }
    #endregion
    public Guid EntryId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreatedById { get; set; }
}
