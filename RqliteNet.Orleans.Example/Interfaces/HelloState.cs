namespace RqliteNet.Orleans.Example.Interfaces;

[Serializable, GenerateSerializer]
[Alias("HelloState")]
public class HelloState
{
    [Id(0)]
    public string Example { get; set; } = string.Empty;
}