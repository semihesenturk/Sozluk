using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.Models.Queries;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.User;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    #region Variables
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;
    #endregion

    #region Constructor
    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.configuration = configuration;
    }
    #endregion

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (dbUser == null)
            throw new DatabaseValidationException("User not found!");

        var pass = PasswordEncryptor.Encrypt(request.Password);

        if (dbUser.Password != pass)
            throw new DatabaseValidationException("Password is wrong!");

        if (!dbUser.EmailConfirmed)
            throw new DatabaseValidationException("Email Address is not confirmed yet!");

        var result = mapper.Map<LoginUserViewModel>(dbUser);

        result.Token = "";

        return result;
    }


}

