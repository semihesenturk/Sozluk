using MediatR;

namespace Sozluk.Common.Models.RequestModels;
public class CreateEntryCommand : IRequest<Guid>
{
    #region Constructors
    public CreateEntryCommand()
    {

    }

    public CreateEntryCommand(string subject, string content, Guid? createdById)
    {
        Subject = subject;
        Content = content;
        CreatedById = createdById;
    }
    #endregion

    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid? CreatedById { get; set; }
}
