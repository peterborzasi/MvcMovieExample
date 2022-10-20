using Application.Contexts;
using Domain.Getaways;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{

    public static void AddContexts(this IServiceCollection services)
    {
        services.AddScoped<GetAllMoviesContext, GetAllMoviesContext>();
        services.AddScoped<CreateMovieContext, CreateMovieContext>();

    }
}