using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Services;
using BarbershopManagement_Services.Interfaces;
using BarbershopManagement_Services.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Barbershop_Management.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddServices(services);
            AddInfrastructure(services, configuration);
            AddControllers(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        private static void AddControllers(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBarberService, BarberService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IDashboardService, DashboardService>();

            //services.AddAutoMapper(typeof(BarberMappings).Assembly);
        }
        private static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BarbershopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(BarberMappings).Assembly);
        }
    }
}
