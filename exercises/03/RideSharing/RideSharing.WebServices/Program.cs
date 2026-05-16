using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCF.Queue.Common.Configuration;
using RideSharing.Data;
using RideSharing.WebServices.Infrastructure;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    builder.Services.AddServiceModelServices();
    builder.Services.AddServiceModelMetadata();
    builder.Services.AddQueueTransport();

    builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

    Log.Information("Injecting DI;");
    builder.Services.AddDatabaseRideContext(builder.Configuration);
    builder.Services.AddRepository();
    builder.Services.AddServices();

    var app = builder.Build();

    // Ensure the database is created
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<RideSharingDbContext>();
        db.Database.EnsureCreated();
    }

    app.UseSerilogRequestLogging();
    app.UseServiceModel(serviceBuilder =>
    {
        serviceBuilder.WcfServiceBuilder();

        var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
        serviceMetadataBehavior.HttpsGetEnabled = true;
    });

    Log.Information("Ride Sharing is starting.");
    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandler exception!");
}
finally
{
    Log.Information("Ride Sharing is shuting down.");
    await Log.CloseAndFlushAsync();
}