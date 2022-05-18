using MediatR;

namespace Sozluk.Application.Features.Commands.Entry.CreateFav;
public class CreateEntryFavCommand : IRequest<bool>
{
    #region Constructor
    public CreateEntryFavCommand(Guid? entryId, Guid? userId)
    {
        EntryId = entryId;
        UserId = userId;
    }
    #endregion

    public Guid? EntryId { get; set; }
    public Guid? UserId { get; set; }
}
