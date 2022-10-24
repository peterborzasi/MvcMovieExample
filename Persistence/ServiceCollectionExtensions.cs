using Domain.Getaways;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Getaways;

namespace Persistence
{
    public static class ServiceCollectionExtensions
    {

        public static void AddGetaways(this IServiceCollection services)
        {
            services.AddScoped<IGetAllMoviesGetaway, GetAllMoviesGetaway>();
            services.AddScoped<ICreateMovieGetaway, CreateMovieGetaway>();
            services.AddScoped<IEditMovieGetaway, EditMovieGetaway>();

        }
    }
}