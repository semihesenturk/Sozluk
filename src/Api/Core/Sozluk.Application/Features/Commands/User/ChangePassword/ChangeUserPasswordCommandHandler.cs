using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.User.ChangePassword;
public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
{
    #region Variables
    private readonly IUserRepository _userRepository;
    #endregion

    #region Constructor
    public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if (!request.UserId.HasValue)
            throw new ArgumentNullException(nameof(request.UserId));

        var dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);

        if (dbUser is null)
            throw new DatabaseValidationException("User not found!");

        var encryptedPassword = PasswordEncryptor.Encrypt(request.OldPassword);

        if (dbUser.Password != encryptedPassword)
            throw new DatabaseValidationException("Old password wrong!");

        dbUser.Password = encryptedPassword;

        await _userRepository.UpdateAsync(dbUser);

        return true;
    }
}

