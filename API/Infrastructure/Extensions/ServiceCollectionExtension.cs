using BLL.Infractructure.AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddCustomServices(this IServiceCollection services)
        {   
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Database
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDBContext>(option =>
                    option.UseSqlServer(connection));

            //AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AppMappingProfile());
            });

            services.AddSingleton(config.CreateMapper());           

            // Logging
            services.AddLogging();
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
