using Microsoft.EntityFrameworkCore;
using SpeedUpAPI_Redis.ExtensionMethods;
using SpeedUpAPI_Redis.Models;
using SpeedUpAPI_Redis.Services.CachingServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ABContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));

});

// Adding Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "cars";
    //options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
    //{
    //    EndPoints = { "product.redis:6379" },
    //    ConnectTimeout = 10000, // Increase timeout to 10 seconds
    //    SyncTimeout = 10000,    // Increase sync timeout to 10 seconds
    //};
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRedisService,RedisService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Apply Migration

    //app.ApplyMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
