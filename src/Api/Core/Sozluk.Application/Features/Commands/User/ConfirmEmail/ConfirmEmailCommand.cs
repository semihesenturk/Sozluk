using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure.Exceptions;

namespace Sozluk.Application.Features.Commands.User.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<bool>
{
    public Guid ConfirmationId { get; set; }
}

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
{
    #region Variables
    private readonly IUserRepository _userRepository;
    private readonly IEmailConfirmationRepository _emailConfirmationRepository;
    #endregion

    #region Constructor
    public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
    {
        _userRepository = userRepository;
        _emailConfirmationRepository = emailConfirmationRepository;
    }
    #endregion

    public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var confirmation = await _emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);

        if (confirmation is null)
            throw new DatabaseValidationException("Confirmation not found!");

        var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);

        if (dbUser is null)
            throw new DatabaseValidationException("User not found with this email");

        if (dbUser.EmailConfirmed)
            throw new DatabaseValidationException("Email address is already confirmed!");

        await _userRepository.UpdateAsync(dbUser);

        return true;
    }
}
