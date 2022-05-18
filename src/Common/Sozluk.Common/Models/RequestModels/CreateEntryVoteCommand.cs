using MediatR;
using Sozluk.Common.ViewModels;

namespace Sozluk.Common.Models.RequestModels;
public class CreateEntryVoteCommand : IRequest<bool>
{
    public Guid EntryId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreatedById { get; set; }
}
