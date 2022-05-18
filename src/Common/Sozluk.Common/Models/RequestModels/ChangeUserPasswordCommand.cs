using MediatR;

namespace Sozluk.Common.Models.RequestModels;
public class ChangeUserPasswordCommand : IRequest<bool>
{
    #region Constructor
    public ChangeUserPasswordCommand(Guid? userId, string oldPassword, string newPassword)
    {
        UserId = userId;
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
    #endregion

    public Guid? UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

}
