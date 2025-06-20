
//using MediatR;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using Ordering.Application.Commands.Customers.Create;
//using Ordering.Application.Commands.User.Create;
//using Ordering.Application.Common.Interface;
//using Ordering.Infrastructure;
//using Ordering.Infrastructure.Services;
//using System.Reflection;
//using System.Text;

//namespace Ordering.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();

//            //For authentication
//            var _key = builder.Configuration["Jwt:Key"];
//            var _issuer = builder.Configuration["Jwt:Issuer"];
//            var _audience = builder.Configuration["Jwt:Audience"];
//            var _expirtyMinutes = builder.Configuration["Jwt:ExpiryMinutes"];

//            //Configuration for token



//            builder.Services.AddAuthentication(x =>
//            {
//                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(x =>
//            {
//                x.RequireHttpsMetadata = false;
//                x.SaveToken = true;
//                x.TokenValidationParameters = new TokenValidationParameters()
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidAudience = _audience,
//                    ValidIssuer = _issuer,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
//                    ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expirtyMinutes))

//                };
//            });

//            //Dependency injection with key

//           // builder.Services.AddSingleton<ITokenGenerator>( new TokenGenerator(_key,_issuer,_audience,_expirtyMinutes));
//           builder.Services.AddSingleton<ITokenGenerator>(new TokenGenerator(_key,_issuer,_audience,_expirtyMinutes));

//            //Include Infrastructure Dependency

//            builder.Services.AddInfrastructure(builder.Configuration);


//            // Configuration for Sqlite

//            //builder.Services.AddDbContext<OrderingContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//            // Register dependencies


//            // Fixed MediatR Registration (v12.5+ syntax)
//            builder.Services.AddMediatR(cfg =>
//            {
//                cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly);
//                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
//            });

//            builder.Services.AddCors(c =>
//            {
//                c.AddPolicy("CorsPolicy", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//            });


//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            // builder.Services.AddSwaggerGen();

//            builder.Services.AddSwaggerGen(c =>
//            {

//                // To enable authorization using swagger (Jwt)
//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = "Bearer",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer {token}\"",
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//                {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            }
//                        },
//                        new string[] {}

//                    }
//                });

//            });



//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }



//            app.UseHttpsRedirection();
//            // Must be betwwen app.UseRouting() and app.UseEndPoints()
//            // maintain middleware order
//            app.UseCors("CorsPolicy");


//            // Added for authentication

//            // Maintain middleware order
//            app.UseAuthentication();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}


/////*************Second Approached  to make clean  code in program.cs by adding jwt related code in DependencyInjection.cs(AddInfrastr)**************






// Ordering.API/Program.cs
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Ordering.Application.Commands.Customers.Create;
using Ordering.Application.Commands.User.Create;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Consolidated Infrastructure & JWT Configuration
builder.Services.AddInfrastructure(builder.Configuration);

// MediatR Configuration
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});

// CORS Configuration
builder.Services.AddCors(c =>
    c.AddPolicy("CorsPolicy", options =>
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication(); // JWT Authentication
app.UseAuthorization();
app.MapControllers();
app.Run();






