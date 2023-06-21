using System.Collections;
using ScienceArchive.Application;
using ScienceArchive.BusinessLogic;
using ScienceArchive.Infrastructure.Persistence;
using ScienceArchive.Infrastructure.Persistence.Options;

namespace ScienceArchive.Web.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string dbConnectionString;

        if (builder.Environment.IsDevelopment())
        {
            dbConnectionString =
                builder.Configuration.GetConnectionString("PostgreSQL") ??
                throw new NullReferenceException("Cannot get DB connection string from config file!");
        }
        else
        {
            dbConnectionString =
                Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING") ??
                throw new NullReferenceException("Cannot get DB connection string from environment!");
        }

        if (dbConnectionString is null)
        {
            throw new NullReferenceException("Cannot get connection string!");
        }

        var connectionOptions = new ConnectionOptions()
        {
            PostgresConnectionString = dbConnectionString,
        };

        // Register built-in services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register core domain layer services
        builder.Services.RegisterDomainServices();
        builder.Services.RegisterDomainUseCases();

        // Register infrastructure layer services
        builder.Services.RegisterPersistenceConnections(connectionOptions);
        builder.Services.RegisterPersistenceMappers();
        builder.Services.RegisterRepositories();


        // Register application layer services
        builder.Services.RegisterApplicationMappers();
        builder.Services.RegisterInteractors();

        // Register presentation layser services
        builder.Services.RegisterAuth(builder.Configuration, builder.Environment.IsDevelopment());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}

