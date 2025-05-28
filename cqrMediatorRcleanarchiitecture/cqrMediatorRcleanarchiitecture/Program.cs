
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
            //  — Register the actual ValidationBehavior implementation
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddValidatorsFromAssemblyContaining<CreateDeveloperCommandValidator>();


            //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(IPipelineBehavior<,>));

            builder.Services.AddControllers();
          

            // 2. Add MediatR
            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(
               typeof(Program).Assembly,                  // Web API assembly
              typeof(CreateDeveloperCommand).Assembly    // Application assembly
                 ));

            //3
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //4 injecting ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            

           // 5  Add swagger and OpenService
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //6 Add CORS if needed

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // middleware pipeline  configuration
            //1 Global Exception handling
            // 1. Global Exception Handling
            //app.UseExceptionHandler(errorApp =>
            //{
            //    errorApp.Run(async context =>
            //    {
            //        context.Response.ContentType = "application/json";
            //        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

            //        switch (exceptionHandlerFeature?.Error)
            //        {
            //            case NotFoundException notFoundEx:
            //                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            //                await context.Response.WriteAsync(notFoundEx.Message);
            //                break;
            //            case ValidationException validationEx:
            //                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //                await context.Response.WriteAsJsonAsync(validationEx.Errors);
            //                break;
            //            default:
            //                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //                await context.Response.WriteAsync("An unexpected error occurred");
            //                break;
            //        }
            //    });
            //});





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
