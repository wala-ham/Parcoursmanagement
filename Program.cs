using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parcours_management.Controllers;
using System.Reflection;
using MediatR;
using System.Text.Json.Serialization;
using Parcours_management.Data;
using Parcours_management.Data.Repositories.Parcours;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

    // Configuration
    builder.Configuration.AddJsonFile("appsettings.json");

    var services = builder.Services;
    // Services
    services.AddMediatR(Assembly.GetExecutingAssembly());
    //services.AddDbContext<ApplicationDbContext>();
    services.AddScoped<IUnitOfwork, UnitOfWork>();
    services.AddScoped<IParcoursRepository, ParcoursRepository>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run("http://localhost:4000");
