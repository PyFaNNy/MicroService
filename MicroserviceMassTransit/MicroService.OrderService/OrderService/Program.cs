using MassTransit.Contracts;
using OrderService.DbContext;
using OrderService.DbContext.DatabaseInitialization;
using OrderService.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var secction = builder.Configuration.GetSection("RabbitServer");

builder.Services.AddDataBase();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddControllers();
ConfigureServicesMassTransit.ConfigureServices(builder.Services, builder.Configuration, new MassTransitConfiguration
{
    IsDebug = secction.GetValue<bool>("IsDebug"),
    ServiceName = "OrderService",

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeedData(app);

async void SeedData(IHost app)
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
