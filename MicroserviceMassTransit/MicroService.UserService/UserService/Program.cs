using MassTransit.Contracts;
using Microsoft.OpenApi.Models;
using OrderService.DbContext.DatabaseInitialization;
using UserService.DbContext;
using UserService.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var secction = builder.Configuration.GetSection("RabbitServer");

builder.Services.AddDataBase();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
ConfigureServicesMassTransit.ConfigureServices(builder.Services, builder.Configuration, new MassTransitConfiguration
{
    IsDebug = secction.GetValue<bool>("IsDebug"),
    ServiceName = "UserService",

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UserService",
        Description = "ASP.NET Core Web API"
    });
});


var app = builder.Build();

SeedData(app);

void SeedData(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<DatabaseInitializer>();
        seeder.SeedAsync();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
