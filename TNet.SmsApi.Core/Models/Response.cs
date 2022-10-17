namespace TNet.SmsApi.Core.Models;

public class Response
{
    public Response(object? data)
    {
        Data = data?.GetType().GetProperty("Value")?.GetValue(data) ?? data;
    }

    public Response()
    {
    }

    public object? Data { get; set; }

    public int Code { get; set; } = 200;
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
}