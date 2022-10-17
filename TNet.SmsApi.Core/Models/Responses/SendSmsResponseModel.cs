namespace TNet.SmsApi.Core.Models.Responses;

public class SendSmsResponseModel
{
    public SendSmsResponseModel(bool sent)
    {
        Sent = sent;
    }

    public bool Sent { get; set; }
}