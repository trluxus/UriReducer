namespace UriReducer.Application.Services;

public interface IUriReducerService
{
    public Task<string> GenerateUniqueCode();
}
