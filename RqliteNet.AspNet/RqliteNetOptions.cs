namespace RqliteNet.AspNet;

public class RqliteNetOptions
{
    public Uri? Uri { get; set; }

    public string AuthInfo { get; set; } = string.Empty;

    public TimeSpan? PooledConnectionLifetime { get; set; }
}