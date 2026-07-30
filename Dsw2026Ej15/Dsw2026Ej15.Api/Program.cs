
using Dsw2026Ej15.Domain.Interfaz;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Api.Middleware;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Data.Entities.Persistence;
using Dsw2026Ej15.Data.Entities;
namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Dsw2026Ej15Db")));

            builder.Services.AddScoped<IPersistence, PercistenceEf>();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            //builder.Services.AddSingleton<IPersistencia, PersistenceInMemory>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseMiddleware<ExceptionsMiddleware>();

            app.MapControllers();
            app.MapHealthChecks("/health-check");
            app.Run();
        }
    }
}
