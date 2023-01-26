// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wineyard.Models;
using Wineyard.Tools;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        var connectionString = config["ConnectionStrings:wineyard-db"];
        var migrationAssembly = Assembly.GetExecutingAssembly().FullName;
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString, o => o.MigrationsAssembly(migrationAssembly)));
        services.AddTransient<DbInitializer>();
    })
    .Build();

using var scope = host.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<DbInitializer>().Run();

// host.Services.GetRequiredService<DbInitializer>().Run();

host.Run();