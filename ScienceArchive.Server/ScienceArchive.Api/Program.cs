using System.Collections;
using ScienceArchive.Application;
using ScienceArchive.Infrastructure.Persistence;

namespace ScienceArchive.Api;

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
                throw new NullReferenceException("Cannot get DB connection string from config");
        }
        else
        {
            dbConnectionString =
                Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING") ??
                throw new NullReferenceException("Cannot get DB connection string from environment");
        }

        if (String.IsNullOrWhiteSpace(dbConnectionString))
        {
            throw new NullReferenceException("Cannot get DB connection string!");
        }

        // Register built-in services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register own services
        builder.Services.RegisterApplicationLayerMappers();
        builder.Services.RegisterPersistenceLayerMappers();
        builder.Services.RegisterServices();
        builder.Services.RegisterUseCases();
        builder.Services.RegisterRepositories();
        builder.Services.RegisterDbContext(dbConnectionString);
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

