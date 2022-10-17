using Microsoft.Extensions.Options;
using TNet.SmsApi.Core.Interfaces;
using TNet.SmsApi.Core.Models.Settings;

namespace TNet.SmsApi.Core.Implementation.ProviderSelectors;

public class PercentSmsProviderSelector : ISmsProviderSelector
{
    private readonly Dictionary<string, int> _distribution;
    private readonly Random _random = new();

    public PercentSmsProviderSelector(IOptions<ProviderDistribution> distribution)
    {
        _distribution = distribution.Value.ToDictionary();
        if (_distribution.Sum(t => t.Value) != 100)
            throw new Exception("Invalid Configuration");
    }

    public ISmsProvider Select(IEnumerable<ISmsProvider> list)
    {
        var perCent = _random.Next(0, 101);
        var currentSum = 0;
        foreach (var provider in _distribution)
        {
            currentSum += provider.Value;
            if (perCent <= currentSum)
                return list.First(t => t.GetType().Name == provider.Key);
        }

        return null!; //Will never happen, if configuration is right. Actually, It will be always right, because of check in constructor
    }
}