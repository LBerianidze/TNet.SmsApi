using FluentValidation;
using TNet.SmsApi.Core.Models.Requests;

namespace TNet.SmsApi.Infrastructure.Validators;

public class SendSmsValidator : AbstractValidator<SendSmsRequestModel>
{
    public SendSmsValidator()
    {
        RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(5).MaximumLength(20).Custom((phone, context) =>
        {
            if (!phone.StartsWith("+")) context.AddFailure(context.PropertyName, $"{context.DisplayName} should start with +");
            if (!phone.Skip(1).All(Char.IsDigit))
                context.AddFailure(context.PropertyName, $"{context.DisplayName} should contain only digits");
        });
        RuleFor(x => x.Text).NotEmpty();
    }
}