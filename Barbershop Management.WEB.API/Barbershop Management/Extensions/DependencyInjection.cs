using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity.Identity;
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
        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<BarbershopDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(12);
            });
        }
        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("Jwt");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtOptions["ValidIssuer"],
                        ValidAudience = jwtOptions["ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions["SecretKey"]))
                    };
                });

            services.AddAuthorization();
        }
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Warehouse Management API",
                    Version = "v1",
                    Description = "Central API for Warehouse Management System.",
                    Contact = new OpenApiContact
                    {
                        Name = "WMS",
                        Email = "support@wms.uz",
                        Url = new Uri("https://wms.uz")
                    }
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var fullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setup.IncludeXmlComments(fullPath);

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                setup.AddSecurityDefinition("Bearer", jwtSecurityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            };

                setup.AddSecurityRequirement(securityRequirement);

                setup.OperationFilter<CommonErrorResponseFilter>();

                // setup.SchemaFilter<IgnoreSchemaFilter>();
            });

            services.AddSwaggerExamplesFromAssemblyOf<Program>();
        }
        private static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BarbershopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(BarberMappings).Assembly);
        }
    }
}
