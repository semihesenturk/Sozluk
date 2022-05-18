using MediatR;

namespace Sozluk.Application.Features.Commands.Entry.DeleteFav;
public class DeleteEntryFavCommand : IRequest<bool>
{
    #region Constructor
    public DeleteEntryFavCommand(Guid entryId, Guid userId)
    {
        EntryId = entryId;
        UserId = userId;
    }
    #endregion

    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}
