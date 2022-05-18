namespace Sozluk.Common.Events.EntryComment;

public class DeleteEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid CreatedUser { get; set; }
}
