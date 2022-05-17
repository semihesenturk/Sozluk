using FluentValidation;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.User.Login;
public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    #region Constructor
    public LoginUserCommandValidator()
    {
        RuleFor(i => i.EmailAddress)
            .NotNull()
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("{PropertyName} not a valid email address!");

        RuleFor(i => i.Password)
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} should at least be {MinLength} characters");
    }
    #endregion
}
