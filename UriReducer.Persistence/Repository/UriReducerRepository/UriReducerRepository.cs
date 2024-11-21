using Microsoft.EntityFrameworkCore;
using UriReducer.Application.Repository.IUriReducerRepository;
using UriReducer.Domain.Entities;
using UriReducer.Persistence.Context;

namespace UriReducer.Persistence.Repository.UriReducerRepository;

public class UriReducerRepository : BaseRepository<ReducedUri>, IUriReducerRepository
{
    public UriReducerRepository(UriReducerContext context) : base(context)
    {
    }

    public Task<ReducedUri?> GetByUriCode(string uriCode, CancellationToken cancellationToken)
    {
        return Context.ReducedUris.FirstOrDefaultAsync(x => x.UriCode == uriCode, cancellationToken);
    }
}
