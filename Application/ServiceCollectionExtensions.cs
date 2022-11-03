using Microsoft.Extensions.DependencyInjection;
using Application.Contexts.Movies;
using Application.Contexts.Clients;

namespace Application;

public static class ServiceCollectionExtensions
{

    public static void AddContexts(this IServiceCollection services)
    {
        services.AddScoped<GetAllMoviesContext, GetAllMoviesContext>();
        services.AddScoped<GetMovieDetailsContext, GetMovieDetailsContext>();
        services.AddScoped<CreateMovieContext, CreateMovieContext>();
        services.AddScoped<EditMovieContext, EditMovieContext>();
        services.AddScoped<DeleteMovieContext, DeleteMovieContext>();
     
        services.AddScoped<GetAllClientsContext, GetAllClientsContext>();
        services.AddScoped<GetClientDetailsContext, GetClientDetailsContext>();
        services.AddScoped<CreateClientContext, CreateClientContext>();
        services.AddScoped<EditClientContext, EditClientContext>();
        services.AddScoped<DeleteClientContext, DeleteClientContext>();
    }
}