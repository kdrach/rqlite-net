using Orleans.Storage;

namespace Orleans.Persistence.RqliteNet.Providers;

public class RqliteGrainStorageOptions : IStorageProviderSerializerOptions
{
    public required Uri Uri { get; set; }

    public string AuthInfo { get; set; } = string.Empty;

    public TimeSpan? PooledConnectionLifetime { get; set; }

    public required IGrainStorageSerializer GrainStorageSerializer { get; set; }
}