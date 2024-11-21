using Microsoft.EntityFrameworkCore;
using UriReducer.Application.Repository;
using UriReducer.Domain.Common;
using UriReducer.Persistence.Context;

namespace UriReducer.Persistence.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly UriReducerContext Context;

    public BaseRepository(UriReducerContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        entity.DeletedOnUtc = DateTime.UtcNow;

        Context.Add(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedOnUtc = DateTime.UtcNow;
        entity.IsDeleted = true;

        Context.Update(entity);
    }

    public Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }
}
