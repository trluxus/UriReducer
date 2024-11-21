using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UriReducer.Application.Repository;
using UriReducer.Application.Repository.IUriReducerRepository;
using UriReducer.Application.Services;
using UriReducer.Persistence.Context;
using UriReducer.Persistence.Repository;
using UriReducer.Persistence.Repository.UriReducerRepository;
using UriReducer.Persistence.Services;

namespace UriReducer.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("UriReducerContext");
            services.AddDbContext<UriReducerContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUriReducerRepository, UriReducerRepository>();
            services.AddScoped<IUriReducerService, UriReducerService>();
        }
    }
}
