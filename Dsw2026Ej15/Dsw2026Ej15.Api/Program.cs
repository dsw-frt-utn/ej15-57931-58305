
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
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.UseMiddleware<ExceptionsMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHealthChecks("/health-check");
            app.Run();
        }
    }
}
