using Congestion.Application;
using Congestion.Infrastructure;
using Congestion.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CongestionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CongestionDB"));

});
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITollRegistrationService, TollRegistrationService>();
builder.Services.AddScoped<ICongestionRepository, CongestionRepository>();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();



