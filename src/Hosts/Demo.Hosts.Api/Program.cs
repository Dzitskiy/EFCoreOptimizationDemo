using Demo.Application.AppServices.Contexts.Aircraft.Repositories;
using Demo.Application.AppServices.Contexts.Aircraft.Services;
using Demo.Application.AppServices.Contexts.Flight.Builders;
using Demo.Application.AppServices.Contexts.Flight.Repositories;
using Demo.Application.AppServices.Contexts.Flight.Services;
using Demo.Application.AppServices.Contexts.TicketFlight.Builders;
using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Application.AppServices.Interceptors;
using Demo.Contracts.Flight;
using Demo.Contracts.TicketFlight;
using Demo.Hosts.Api.Controllers;
using Demo.Infrastructure.DataAccess;
using Demo.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var includeDocsTypesMarkers = new[]
    {
        // TODO
        typeof(TicketFlightDto),
        typeof(FlightFilterRequest),
        typeof(TicketFlightController)
    };
            
    foreach (var marker in includeDocsTypesMarkers)
    {
        var xmlName = $"{marker.Assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlName);
            
        if (File.Exists(xmlPath))
            s.IncludeXmlComments(xmlPath);
    }
});

// TODO pool
builder.Services.AddDbContext<ReadOnlyDemoDbContext>((sp, options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DemoDb"));
    options.AddInterceptors(sp.GetRequiredService<PerformanceDbQueryInterceptor>());
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IAircraftService, AircraftService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<ITicketFlightService, TicketFlightService>();

builder.Services.AddScoped<IAircraftRepository, AircraftRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketFlightRepository, TicketFlightRepository>();

builder.Services.AddScoped<IFlightPredicateBuilder, FlightPredicateBuilder>();
builder.Services.AddScoped<ITicketFlightPredicateBuilder, TicketFlightPredicateBuilder>();

builder.Services.AddTransient<PerformanceDbQueryInterceptor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();