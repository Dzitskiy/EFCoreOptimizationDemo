using Demo.Application.AppServices.Contexts.Aircraft.Repositories;
using Demo.Application.AppServices.Contexts.Aircraft.Services;
using Demo.Application.AppServices.Contexts.Flight.Builders;
using Demo.Application.AppServices.Contexts.Flight.Repositories;
using Demo.Application.AppServices.Contexts.Flight.Services;
using Demo.Application.AppServices.Contexts.Ticket.Repositories;
using Demo.Application.AppServices.Contexts.Ticket.Services;
using Demo.Application.AppServices.Contexts.TicketFlight.Builders;
using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Application.AppServices.Interceptors;
using Demo.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.ComponentRegistrar;

/// <summary>
/// Регистратор зависимостей.
/// </summary>
public static class Registrar
{
    /// <summary>
    /// Зарегистрировать сервисы.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAircraftService, AircraftService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ITicketFlightService, TicketFlightService>();

        services.AddScoped<IAircraftRepository, AircraftRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITicketFlightRepository, TicketFlightRepository>();

        services.AddScoped<IFlightPredicateBuilder, FlightPredicateBuilder>();
        services.AddScoped<ITicketFlightPredicateBuilder, TicketFlightPredicateBuilder>();

        services.AddTransient<PerformanceDbQueryInterceptor>();

        return services;
    }
}