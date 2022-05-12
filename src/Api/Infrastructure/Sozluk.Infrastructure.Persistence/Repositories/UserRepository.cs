using Sozluk.Api.Domain.Models;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Infrastructure.Persistence.Context;

namespace Sozluk.Infrastructure.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Constructor
    public UserRepository(SozlukContext sozlukContext) : base(sozlukContext)
    {
    } 
    #endregion
}

