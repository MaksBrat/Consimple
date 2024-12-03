using API.Infrastructure;
using API.Infrastructure.Extensions;

namespace Consimple
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCustomServices();
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddSwaggerServices();

            builder.Services.AddMvc();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.ConfigureCustomExceptionMiddleware();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1");
            });

            app.MapControllers();

            await DbInitializer.Seed(app);

            app.Run();
        }
    }
}
