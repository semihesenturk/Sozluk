using Microsoft.EntityFrameworkCore;
using Sozluk.Api.Domain.Models;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Infrastructure.Persistence.Context;

namespace Sozluk.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
{
    public EmailConfirmationRepository(SozlukContext sozlukContext) : base(sozlukContext)
    {
    }
}
