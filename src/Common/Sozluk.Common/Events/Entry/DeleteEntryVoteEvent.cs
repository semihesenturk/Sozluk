﻿namespace Sozluk.Common.Events.Entry;
public class DeleteEntryVoteEvent
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}
