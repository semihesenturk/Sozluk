using Microsoft.EntityFrameworkCore;
using Sozluk.Api.Domain.Models;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Infrastructure.Persistence.Context;

namespace Sozluk.Infrastructure.Persistence.Repositories;

public class EntryRepository : GenericRepository<Entry>, IEntryRepository
{
    public EntryRepository(SozlukContext sozlukContext) : base(sozlukContext)
    {
    }
}
