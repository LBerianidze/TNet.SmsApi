using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TNet.SmsApi.Core.Interfaces.Services;
using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Responses;

namespace TNet.SmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmsController : ControllerBase
{
    private readonly ILogger<SmsController> _logger;
    private readonly IValidator<SendSmsRequestModel> _sendSmsValidator;
    private readonly ISmsService _smsService;

    public SmsController(ILogger<SmsController> logger, ISmsService smsService,
        IValidator<SendSmsRequestModel> sendSmsValidator)
    {
        _logger = logger;
        _smsService = smsService;
        _sendSmsValidator = sendSmsValidator;
    }

    [HttpPost("send")]
    public async Task<SendSmsResponseModel> SendSms(SendSmsRequestModel smsRequestModel)
    {
        var validationResult = await _sendSmsValidator.ValidateAsync(smsRequestModel);
        if (!validationResult.IsValid)
        {
            _logger.LogError($"Error in {nameof(SendSms)} Method: {JsonConvert.SerializeObject(smsRequestModel)}");
            validationResult.AddToModelState(ModelState);
            throw new Exception("Bad Request");
        }

        var response = await _smsService.Send(smsRequestModel);
        return response;
    }
}