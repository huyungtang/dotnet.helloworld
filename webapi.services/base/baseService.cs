using Microsoft.EntityFrameworkCore;
using webapi.core;
using webapi.models;

namespace webapi.services
{
  public abstract class BaseService<TEntity, TKey>(WebapiDBContext dbContext, IContextService context)
    : IDisposable
    where TEntity : Entity, IIdentifiable<TKey>
    where TKey : struct
  {

    #region Properties ####################################################################################################################

    private readonly WebapiDBContext _dbContext = dbContext;

    private readonly IContextService _context = context;

    protected DbSet<TEntity> DbSet
    {
      get
      {
        return _dbContext.Set<TEntity>();
      }
    }

    protected IQueryable<TEntity> All
    {
      get
      {
        return DbSet.AsQueryable();
      }
    }

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public virtual Task<bool> CreateAsync(TEntity entity)
    {
      return CreateCoreAsync(entity);
    }

    public virtual IQueryable<TEntity> GetAvailable()
    {
      var qry = All;

      if (typeof(IDeletedState).IsAssignableFrom(typeof(TEntity)))
      {
        qry = qry.Where(e => !((IDeletedState)e).IsDeleted);
      }

      return qry;
    }

    public virtual IQueryable<TEntity> GetAvailable(Func<TEntity, bool> predicate)
    {
      return GetAvailable().Where(predicate).AsQueryable();
    }

    public virtual ValueTask<TEntity?> GetByIdAsync(TKey id)
    {
      return DbSet.FindAsync(id);
    }

    public virtual Task<bool> UpdateAsync(TEntity entity)
    {
      return UpdateCoreAsync(entity);
    }

    public virtual Task<bool> DeleteAsync(TEntity entity)
    {
      return DeleteCoreAsync(entity);
    }

    public void Dispose()
    {
      _dbContext?.Dispose();
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################

    private async Task<bool> CreateCoreAsync(TEntity entity)
    {
      entity.IsA<ICreatedState>(obj =>
      {
        obj!.CreatedAt = _context.NowUnixMilli;
        obj!.CreaterId = _context.CurrentUser?.Id ?? 0;
      });

      DbSet.Add(entity);

      return await Commit();
    }

    private async Task<bool> UpdateCoreAsync(TEntity entity)
    {
      entity.IsA<IUpdatedState>(obj =>
      {
        obj!.UpdatedAt = _context.NowUnixMilli;
        obj!.UpdaterId = _context.CurrentUser?.Id ?? 0;
      });

      DbSet.Attach(entity);
      _dbContext.Entry(entity).State = EntityState.Modified;

      return await Commit();
    }

    private async Task<bool> DeleteCoreAsync(TEntity entity)
    {
      if (entity.IsA<IDeletedState>(obj =>
      {
        obj!.IsDeleted = true;
      }))
      {
        return await UpdateCoreAsync(entity);
      }

      DbSet.Remove(entity);

      return await Commit();
    }

    private async Task<bool> Commit()
    {
      return (await _dbContext.SaveChangesAsync()).Equals(1);
    }

    #endregion ############################################################################################################################

  }

}