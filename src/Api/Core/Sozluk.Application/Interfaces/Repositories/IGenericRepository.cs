using Sozluk.Api.Domain.Models;
using System.Linq.Expressions;

namespace Sozluk.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{

    #region Add operations
    Task<int> AddAsync(TEntity entity);

    int Add(TEntity entity);

    int Add(IEnumerable<TEntity> entities);

    Task<int> AddAsync(IEnumerable<TEntity> entities);
    #endregion


    #region Update operations
    Task<int> UpdateAsync(TEntity entity);

    int Update(TEntity entity);
    #endregion


    #region Delete operations
    Task<int> DeleteAsync(TEntity entity);

    int Delete(TEntity entity);

    Task<int> DeleteAsync(Guid id);

    int Delete(Guid id);

    bool DeleteRange(Expression<Func<TEntity, bool>> predicate);

    Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);
    #endregion


    #region AddOrUpdate operations
    Task<int> AddOrUpdateAsync(TEntity entity);

    int AddOrUpdate(TEntity entity);

    IQueryable<TEntity> AsQueryable();
    #endregion


    #region Get operations
    Task<List<TEntity>> GetAll(bool noTracking = true);

    Task<List<TEntity>> GetList(
        Expression<Func<TEntity, bool>> predicate,
        bool noTracking = true,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetByIdAsync(
        Guid id,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetSingleAsync(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> FirstOrDefaultAsync(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> Get(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);
    #endregion


    #region Bulk Operations
    Task BulkDeleteById(IEnumerable<Guid> ids);

    Task BulkDelete(Expression<Func<TEntity, bool>> predicate);

    Task BulkDelete(IEnumerable<TEntity> entites);

    Task BulkUpdate(IEnumerable<TEntity> entities);

    Task BulkAdd(IEnumerable<TEntity> entites);
    #endregion
}