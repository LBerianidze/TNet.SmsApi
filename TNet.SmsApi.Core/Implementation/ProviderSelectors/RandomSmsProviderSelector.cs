using TNet.SmsApi.Core.Interfaces;

namespace TNet.SmsApi.Core.Implementation.ProviderSelectors;

public class RandomSmsProviderSelector : ISmsProviderSelector
{
    private readonly Random _random = new();

    public ISmsProvider Select(IEnumerable<ISmsProvider> list)
    {
        var cp = list.ToArray(); //Enumeration Escape
        return cp[_random.Next(0, cp.Length)];
    }
}