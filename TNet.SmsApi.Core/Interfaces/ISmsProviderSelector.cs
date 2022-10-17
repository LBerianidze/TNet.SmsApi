namespace TNet.SmsApi.Core.Interfaces;

public interface ISmsProviderSelector
{
    ISmsProvider Select(IEnumerable<ISmsProvider> list);
}