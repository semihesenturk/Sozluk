using Sozluk.Common.ViewModels;

namespace Sozluk.Common.Events.Entry;
public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreatedById { get; set; }
}
