using KaniniTrip.Profile.Domain.Interfaces.Repository;
using KaniniTrip.Profile.Domain.Interfaces.Services;
using KaniniTrip.Profile.Domain.Services;
using KaniniTrip.Profile.Infrastructure.DataContext;
using KaniniTrip.Profile.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddDbContext<KaniniTripDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "AdminSkill"),
                        sqlServerOptionsAction: b => b.MigrationsAssembly("KaniniTrip.Profile.Application"));
});
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService,ProfileService>();

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
