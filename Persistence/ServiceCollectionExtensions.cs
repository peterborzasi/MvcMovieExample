using Microsoft.Extensions.DependencyInjection;
using Domain.Getaways.Movies;
using Domain.Getaways.Clients;
using Persistence.Getaways.Movies;
using Persistence.Getaways.Clients;

namespace Persistence;

public static class ServiceCollectionExtensions
{

    public static void AddGetaways(this IServiceCollection services)
    {
        services.AddScoped<IGetAllMoviesGetaway, GetAllMoviesGetaway>();
        services.AddScoped<IGetMovieDetailsGetaway, GetMovieDetailsGetaway>();
        services.AddScoped<ICreateMovieGetaway, CreateMovieGetaway>();
        services.AddScoped<IEditMovieGetaway, EditMovieGetaway>();
        services.AddScoped<IDeleteMovieGetaway, DeleteMovieGetaway>();

        services.AddScoped<IGetAllClientsGetaway, GetAllClientsGetaway>();
        services.AddScoped<IGetClientDetailsGetaway, GetClientDetailsGetaway>();
        services.AddScoped<ICreateClientGetaway, CreateClientGetaway>();
        services.AddScoped<IEditClientGetaway, EditClientGetaway>();
        services.AddScoped<IDeleteClientGetaway, DeleteClientGetaway>();
    }
}