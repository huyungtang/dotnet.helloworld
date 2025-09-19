using Microsoft.EntityFrameworkCore;
using webapi.core;
using webapi.core.models;
using webapi.models;

namespace webapi.services
{
  public abstract class BaseService<TEntity, TKey>(WebapiContext context)
    : IDisposable
    where TEntity : Entity, IIdentifiable<TKey>
    where TKey : struct
  {

    #region Properties ####################################################################################################################

    private readonly WebapiContext _context = context;

    protected DbSet<TEntity> DbSet
    {
      get
      {
        return _context.Set<TEntity>();
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

    public virtual Task<TEntity?> GetByIdAsync(TKey id)
    {
      return DbSet.FindAsync(id).AsTask();
    }

    public virtual Task<bool> UpdateAsync(TEntity entity)
    {
      return UpdateCoreAsync(entity);
    }

    public void Dispose()
    {
      _context?.Dispose();
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################

    private async Task<bool> CreateCoreAsync(TEntity entity)
    {
      // TODO: add shared properties, like created time, creater ...
      DbSet.Add(entity);

      return (await _context.SaveChangesAsync()).Equals(1);
    }

    private async Task<bool> UpdateCoreAsync(TEntity entity)
    {
      DbSet.Update(entity);

      return (await _context.SaveChangesAsync()).Equals(1);
    }

    #endregion ############################################################################################################################

  }

}