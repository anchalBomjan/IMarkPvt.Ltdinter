
using DeveloperDetailsManagementSystem.Application;
using DeveloperDetailsManagementSystem.Domain;
using DeveloperDetailsManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DeveloperDetailsManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //injecting ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>(); 
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<AddressService>();
            builder.Services.AddScoped<DeveloperService>();
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
