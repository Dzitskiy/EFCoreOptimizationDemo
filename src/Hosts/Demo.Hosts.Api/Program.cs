using Demo.Application.AppServices.Interceptors;
using Demo.Infrastructure.ComponentRegistrar;
using Demo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ => { });

builder.Services.AddDbContext<ReadOnlyDemoDbContext>((sp, options) =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseNpgsql(builder.Configuration.GetConnectionString("DemoDb"));
    options.AddInterceptors(sp.GetRequiredService<PerformanceDbQueryInterceptor>());
    options.EnableSensitiveDataLogging();
});

builder.Services.AddServices();

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