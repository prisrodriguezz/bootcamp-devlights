using Bloque_2.Interfaces;
using Bloque_2.Repositories;
using Bloque_2.Services;

namespace Bloque_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // registrar dependencias
            builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
            builder.Services.AddScoped<IProductoService, ProductoService>();

            // configurar Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
