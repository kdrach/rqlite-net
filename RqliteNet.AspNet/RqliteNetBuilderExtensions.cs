using Microsoft.Extensions.Options;

namespace RqliteNet.AspNet;

public static class RqliteNetBuilderExtensions
{
    public static IServiceCollection AddRqliteNet(this IServiceCollection services, Action<RqliteNetOptions> options)
    {
        services.AddOptions<RqliteNetOptions>().Configure(options);

        return services.AddRqliteNet();
    }

    public static IServiceCollection AddRqliteNet(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RqliteNetOptions>(configuration);

        return services.AddRqliteNet();
    }

    private static IServiceCollection AddRqliteNet(this IServiceCollection services)
    {
        services.AddSingleton<IRqliteNetClient>(sp =>
        {
            var opt = sp.GetRequiredService<IOptionsMonitor<RqliteNetOptions>>();
            ArgumentNullException.ThrowIfNull(opt.CurrentValue.Uri, "RqliteNetOptions.Uri");

            return new RqliteNetClient(opt.CurrentValue.Uri, opt.CurrentValue.PooledConnectionLifetime, opt.CurrentValue.AuthInfo);
        });

        return services;
    }
}