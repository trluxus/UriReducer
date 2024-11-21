using UriReducer.Domain.Entities;

namespace UriReducer.Application.Repository.IUriReducerRepository;

public interface IUriReducerRepository : IBaseRepository<ReducedUri>
{
    Task<ReducedUri?> GetByUriCode(string uriCode, CancellationToken cancellationToken);
}

