using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Responses;

namespace TNet.SmsApi.Core.Interfaces.Services;

public interface ISmsService
{
    Task<SendSmsResponseModel> Send(SendSmsRequestModel smsRequestModel);
}