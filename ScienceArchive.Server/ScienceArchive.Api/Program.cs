namespace ScienceArchive.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var dbConnectionString = builder.Configuration.GetConnectionString("PostgreSQL");

        if (String.IsNullOrWhiteSpace(dbConnectionString))
        {
            throw new NullReferenceException("Cannot get DB connection string!");
        }

        // Register built-in services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register own services
        builder.Services.RegisterServices();
        builder.Services.RegisterUseCases();
        builder.Services.RegisterRepositories();
        builder.Services.RegisterDbContext(dbConnectionString);
        builder.Services.RegisterAuth(builder.Configuration);

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

