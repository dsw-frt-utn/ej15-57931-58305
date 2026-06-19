
using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaz;

namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen(); 
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();
            builder.Services.AddHealthChecks();
            var app = builder.Build();
            app.UseMiddleware<ExceptionsMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            //app.MapHealthChecks("/health-check");
            app.Run();
        }
    }
}
