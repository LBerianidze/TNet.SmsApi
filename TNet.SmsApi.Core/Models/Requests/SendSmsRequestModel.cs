namespace TNet.SmsApi.Core.Models.Requests;

public class SendSmsRequestModel
{
    public string PhoneNumber { get; set; }
    public string Text { get; set; }
}