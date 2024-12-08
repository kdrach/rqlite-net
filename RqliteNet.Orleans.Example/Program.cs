using Microsoft.Extensions.Hosting;
using Orleans.Persistence.RqliteNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RqliteNet.Orleans.Example.Interfaces;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering();

        silo.AddRqliteGrainStorage("rqlite", opt =>
        {
            opt.Uri = new Uri("http://127.0.0.1:4001");
            opt.AuthInfo = string.Empty;
            opt.PooledConnectionLifetime = TimeSpan.FromHours(1);
        });
    })
    .UseConsoleLifetime();

using IHost host = builder.Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
var hello = client.GetGrain<IHello>(0);

Console.WriteLine(await hello.SayHello("Hello"));
Console.WriteLine(await hello.SayHello("World"));

await host.StopAsync();