namespace RqliteNet.Orleans.Example.Interfaces;

[Alias("IHello")]
public interface IHello : IGrainWithIntegerKey
{
    [Alias("SayHello")]
    Task<string> SayHello(string greeting);
}