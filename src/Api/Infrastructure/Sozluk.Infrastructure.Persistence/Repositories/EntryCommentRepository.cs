using Microsoft.EntityFrameworkCore;
using Sozluk.Api.Domain.Models;

namespace Sozluk.Infrastructure.Persistence.Repositories;
public class EntryCommentRepository : GenericRepository<EntryComment>
{
    public EntryCommentRepository(DbContext sozlukContext) : base(sozlukContext)
    {
    }
}
