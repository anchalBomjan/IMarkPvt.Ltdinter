
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ordering.Application.Common.Interface;
using Ordering.Infrastructure.Services;
using System.Text;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.

            builder.Services.AddControllers();

            //For authentication
            var _key = builder.Configuration["Jwt:Key"];
            var _issuer = builder.Configuration["Jwt:Issuer"];
            var _audience = builder.Configuration["Jwt:Audience"];
            var _expirtyMinutes = builder.Configuration["Jwt:ExpiryMinutes"];

            //Configuration for token



            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = _audience,
                    ValidIssuer = _issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expirtyMinutes))

                };
            });

            //Dependency injection with key

           // builder.Services.AddSingleton<ITokenGenerator>( new TokenGenerator(_key,_issuer,_audience,_expirtyMinutes));
           builder.Services.AddSingleton<ITokenGenerator>(new TokenGenerator(_key,_issuer,_audience,_expirtyMinutes));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
