//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Ordering.Application.Common.Interface;
//using Ordering.Infrastructure.Data;
//using Ordering.Infrastructure.Identity;
//using Ordering.Infrastructure.Repositories.Command.Base;
//using Ordering.Infrastructure.Repositories.Command;
//using Ordering.Infrastructure.Repositories.Query.Base;
//using Ordering.Infrastructure.Repositories.Query;
//using Ordering.Infrastructure.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Ordering.Core.Repositories.Query;
//using Ordering.Core.Repositories.Query.Base;
//using Ordering.Core.Repositories.Command.Base;
//using Ordering.Core.Repositories.Command;

//namespace Ordering.Infrastructure
//{
//    public  static class DependencyInjection
//    {

//        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
//            IConfiguration configuration)
//        {
//            services.AddDbContext<OrderingContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
//                b => b.MigrationsAssembly(typeof(OrderingContext).Assembly.FullName)
//                ));

//            services.AddIdentity<ApplicationUser, IdentityRole>()
//            .AddEntityFrameworkStores<OrderingContext>()
//            .AddDefaultTokenProviders();

//            services.Configure<IdentityOptions>(options =>
//            {
//                // Default Lockout settings.
//                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//                options.Lockout.MaxFailedAccessAttempts = 5;
//                options.Lockout.AllowedForNewUsers = true;
//                // Default Password settings.
//                options.Password.RequireDigit = false;
//                options.Password.RequireLowercase = true;
//                options.Password.RequireNonAlphanumeric = false; // For special character
//                options.Password.RequireUppercase = false;
//                options.Password.RequiredLength = 6;
//                options.Password.RequiredUniqueChars = 1;
//                // Default SignIn settings.
//                options.SignIn.RequireConfirmedEmail = false;
//                options.SignIn.RequireConfirmedPhoneNumber = false;
//                options.User.RequireUniqueEmail = true;
//            });


//            services.AddScoped<IIdentityService, IdentityService>();

//            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
//            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
//            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
//            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();


//            return services;
//        }
//    }
//}

///////////////***********************Second Approached***************************
///




using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ordering.Application.Common.Interface;
using Ordering.Core.Repositories.Command.Base;
using Ordering.Core.Repositories.Command;
using Ordering.Core.Repositories.Query.Base;
using Ordering.Core.Repositories.Query;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Identity;
using Ordering.Infrastructure.Repositories.Command;
using Ordering.Infrastructure.Repositories.Command.Base;
using Ordering.Infrastructure.Repositories.Query;
using Ordering.Infrastructure.Repositories.Query.Base;
using Ordering.Infrastructure.Services;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Database Configuration
            services.AddDbContext<OrderingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(OrderingContext).Assembly.FullName)
                ));

            // Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<OrderingContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });

            // JWT Authentication Configuration
            services.ConfigureJwtAuthentication(configuration);

            // Token Generator Service
            services.AddSingleton<ITokenGenerator>(_ =>
                new TokenGenerator(
                    configuration["Jwt:Key"]!,
                    configuration["Jwt:Issuer"]!,
                    configuration["Jwt:Audience"]!,
                    configuration["Jwt:ExpiryMinutes"]!
                )
            );

            // Infrastructure Services
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();

            return services;
        }

        private static void ConfigureJwtAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var key = configuration["Jwt:Key"];
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var expiryMinutes = configuration["Jwt:ExpiryMinutes"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
                    ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(expiryMinutes))
                };
            });
        }
    }
}





