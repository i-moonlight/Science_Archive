using ScienceArchive.Application;
using ScienceArchive.BusinessLogic;
using ScienceArchive.Infrastructure.Persistence;
using ScienceArchive.Web.Api.Auth;
using ScienceArchive.Web.Api.Middleware;

using ConfigurationManager = ScienceArchive.Web.Api.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

var connectionOptions = ConfigurationManager.GetConnectionOptions(builder);
var applicationOptions = ConfigurationManager.GetApplicationOptions(builder);

// Register built-in services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application-specific services
builder.Services.RegisterDomainLayer();
builder.Services.RegisterPersistenceLayer(connectionOptions);
builder.Services.RegisterApplicationLayer(applicationOptions);

// Register presentation layer services
builder.Services.RegisterAuth(builder.Configuration, builder.Environment.IsDevelopment());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Register middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();