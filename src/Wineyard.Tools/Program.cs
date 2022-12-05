// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wineyard.Models;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration
            .GetSection("ConnectionStrings:ApplicationContext").Value;
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString, o =>
                o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
    })
    .Build();

await host.RunAsync();

