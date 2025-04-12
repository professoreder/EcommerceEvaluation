using Ecommerce.Application;
using Ecommerce.Application.Sales.CreateSale;
using Ecommerce.Application.Sales.DeleteSale;
using Ecommerce.Application.Sales.PatchSale;
using Ecommerce.Common.HealthChecks;
using Ecommerce.Common.Logging;
using Ecommerce.Common.Security;
using Ecommerce.Common.Validation;
using Ecommerce.Domain.Events;
using Ecommerce.IoC;
using Ecommerce.ORM;
using Ecommerce.WebApi.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;
using Serilog;
using System.Reflection;

namespace Ecommerce.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Ecommerce Developer Evaluation",
                        Version = "v1"
                    });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ecommerce.ORM")
                )
            );

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Configure Rebus
            builder.Services.AddRebus(configure => configure
                .Logging(l => l.Serilog())
                .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "sales"))
                .Routing(r => r.TypeBased()
                    .Map<CreateSaleEvent>("sales")
                    .Map<DeleteSaleEvent>("sales")
                    .Map<PatchSaleEvent>("sales"))
            );

            // Register Rebus handlers
            builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateSaleEventHandler>();
            builder.Services.AutoRegisterHandlersFromAssemblyOf<DeleteSaleEventHandler>();
            builder.Services.AutoRegisterHandlersFromAssemblyOf<PatchSaleEventHandler>();

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<UserClaimsMiddleware>();

            app.UseBasicHealthChecks();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
