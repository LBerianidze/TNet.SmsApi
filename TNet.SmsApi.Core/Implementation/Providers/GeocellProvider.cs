﻿using TNet.SmsApi.Core.Interfaces;
using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Responses;

namespace TNet.SmsApi.Core.Implementation.Providers;

public class GeocellProvider : ISmsProvider
{
    public async Task<SendSmsResponseModel> Send(SendSmsRequestModel smsRequestModel)
    {
        //Logic for sending sms using Geocell
        return await Task.FromResult(new SendSmsResponseModel(true));
    }
}