using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Services;
using BarbershopManagement_Services.Interfaces;
using BarbershopManagement_Services.Mappings;
using BarbershopManagement_Services.Validator.Barber;
using Newtonsoft.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

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

            services.AddValidatorsFromAssemblyContaining<EmployeeForCreateValidator>();
            services.AddFluentValidationAutoValidation();

            return services;
        }
        private static void AddControllers(IServiceCollection services)
        {
            services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     options.SerializerSettings.Formatting = Formatting.Indented;
                 });

            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IServiceService, ServicesServic>();

            //services.AddAutoMapper(typeof(BarberMappings).Assembly);
        }
        private static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BarbershopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(EmployeeMappings).Assembly);
        }
    }
}
