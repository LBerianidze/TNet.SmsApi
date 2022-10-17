using System.Diagnostics;
using TNet.SmsApi.Core.Interfaces;
using TNet.SmsApi.Core.Interfaces.Services;
using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Responses;

namespace TNet.SmsApi.Core.Implementation.Services;

public class SmsService : ISmsService
{
    private readonly ISmsProvider _currentProvider;

    public SmsService(ISmsProviderSelector providerSelector, IEnumerable<ISmsProvider> providers)
    {
        _currentProvider = providerSelector.Select(providers);
    }

    public async Task<SendSmsResponseModel> Send(SendSmsRequestModel smsRequestModel)
    {
        //Debug.WriteLine($"Message will be sent using: {_currentProvider.GetType().Name}"); //Debug Check
        var result = await _currentProvider.Send(smsRequestModel);
        //e.x Save in Database
        return result;
    }
}