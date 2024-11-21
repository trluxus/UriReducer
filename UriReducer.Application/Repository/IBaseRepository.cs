using UriReducer.Domain.Common;

namespace UriReducer.Application.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Delete(T entity);
    Task<T?> Get(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
