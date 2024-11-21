using UriReducer.Application.Repository;
using UriReducer.Persistence.Context;

namespace UriReducer.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly UriReducerContext _context;

    public UnitOfWork(UriReducerContext context)
    {
        _context = context;
    }

    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
