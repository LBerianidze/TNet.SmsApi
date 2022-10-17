using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Responses;

namespace TNet.SmsApi.Core.Interfaces;

public interface ISmsProvider
{
    Task<SendSmsResponseModel> Send(SendSmsRequestModel smsRequestModel);
}