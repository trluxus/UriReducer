using Microsoft.EntityFrameworkCore;
using UriReducer.Application.Services;
using UriReducer.Domain;
using UriReducer.Persistence.Context;

namespace UriReducer.Persistence.Services;

public class UriReducerService(UriReducerContext dbContext) : IUriReducerService
{
    private readonly Random random = new();

    public async Task<string> GenerateUniqueCode()
    {
        var codeChars = new char[UriRecucerSettings.Length];

        while (true)
        {
            for (var i = 0; i < UriRecucerSettings.Length; i++)
            {
                var randomIndex = random.Next(UriRecucerSettings.Alphabet.Length - 1);

                codeChars[i] = UriRecucerSettings.Alphabet[randomIndex];
            }
            var uriCode = new string(codeChars);

            if (!await dbContext.ReducedUris.AnyAsync(s => s.UriCode == uriCode))
            {
                return uriCode;
            }
        }
    }

}
