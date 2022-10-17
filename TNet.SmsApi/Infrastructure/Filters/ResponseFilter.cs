using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TNet.SmsApi.Core.Models;

namespace TNet.SmsApi.Infrastructure.Filters;

public class ResponseFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
        {
            context.Result = new JsonResult(new Response(context.Result!));
        }
        else
        {
            if (!context.ModelState.IsValid)
                context.Result = new JsonResult(new Response
                {
                    Message = "Bad Request",
                    Code = 401,
                    Errors = context.ModelState.SelectMany(t => t.Value!.Errors).Select(t => t.ErrorMessage)
                });
            else
                context.Result = new JsonResult(new Response { Message = context.Exception.Message });
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}