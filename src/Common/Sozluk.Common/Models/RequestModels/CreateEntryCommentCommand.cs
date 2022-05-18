using MediatR;

namespace Sozluk.Common.Models.RequestModels;
public class CreateEntryCommentCommand : IRequest<Guid>
{
    #region Constructor
    public CreateEntryCommentCommand()
    {
    }
    public CreateEntryCommentCommand(Guid entryId, string content, Guid createdById)
    {
        EntryId = entryId;
        Content = content;
        CreatedById = createdById;
    }
    #endregion

    public Guid? EntryId { get; set; }
    public string Content { get; set; }
    public Guid? CreatedById { get; set; }
}
