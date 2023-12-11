using KaniniTrip.Package.Domain.Interfaces.Repository;
using KaniniTrip.Package.Domain.Interfaces.Services;
using KaniniTrip.Package.Domain.Services;
using KaniniTrip.Package.Infrastructure.DataContext;
using KaniniTrip.Package.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(); builder.Services.AddDbContext<KaniniTripDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "Packages"),
                        sqlServerOptionsAction: b => b.MigrationsAssembly("KaniniTrip.Package.Application"));
});
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();
#region CORS Configuration
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
