﻿namespace Sozluk.Common.Events.EntryComment;

public class DeleteEntryCommentFavEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid CreatedById { get; set; }
}
