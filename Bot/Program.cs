// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Bot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

if (!File.Exists("appsettings.json"))
{
    Console.WriteLine("No exist config file, create it now...");

    var assm = Assembly.GetExecutingAssembly();
    await using var istr = assm.GetManifestResourceStream("Bot.Resources.appsettings.json")!;
    await using var temp = File.Create("appsettings.json");
    istr.CopyTo(temp);

    istr.Close();
    temp.Close();

    Console.WriteLine("Please Edit the appsettings.json to set configs .");
    
    Environment.Exit(0);
}

var host = Host.CreateDefaultBuilder()
    .ConfigureAppSettings()
    .ConfigureServices((context, services) =>
    {
        services.AddMemoryCache();
        services.ConfigureCustomServices(context.Configuration);
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();