using Demo.Application.AppServices.Interceptors;
using Demo.Infrastructure.ComponentRegistrar;
using Demo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ => { });

builder.Services.AddDbContext<ReadOnlyDemoDbContext>((sp, options) =>
{
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