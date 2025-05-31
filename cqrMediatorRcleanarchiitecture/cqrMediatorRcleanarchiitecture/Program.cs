
using cqrsMediator.Application.Common.Behaviors;
using cqrsMediator.Application.Common.Exceptions;
using cqrsMediator.Application.Common.Mappings;
using cqrsMediator.Application.Developers.Commands.CreateDeveloper;
using cqrsMediator.Domain.Interfaces;
using cqrsMediator.Infrastrusture.Presistance;
using cqrsMediator.Infrastrusture.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace cqrMediatorRcleanarchiitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //1  Add services to the container.
            builder.Services.AddScoped<IDeveloperRepository, GetAllDeveloperByAddressIdRepository>();
            
         
            // 2: Add controllers
            builder.Services.AddControllers();

            // 3. Configure API behavior options (MUST come right after AddControllers)
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // 4: Add MediatR
            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(
               typeof(Program).Assembly,                  // Web API assembly
              typeof(CreateDeveloperCommand).Assembly    // Application assembly
                 ));


            // 5 — Register validation Pipeline behaviour 
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddValidatorsFromAssemblyContaining<CreateDeveloperCommandValidator>();
            //6: automapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //7 injecting ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            //8  Add swagger and OpenService
            //9 Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //6 Add CORS if needed

            var app = builder.Build();

            // 1 Exception handling First
            app.UseMiddleware<ExceptionHandlingMiddleware>(); // this must include at first for all validation services added




            //2 Enable swagger UI in Developement
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //3 apply security  middleware
            // app.UseCors("AllowAll"); // If CORS is needed
            app.UseHttpsRedirection();

            //4 authorization and authentication
            app.UseAuthentication();
            app.UseAuthorization();

            //5 map Controller
            app.MapControllers();

            // 6 Add migration

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<ApplicationDbContext>();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while migrating the database");
            //    }
            //}

            app.Run();
        }
    }
}





