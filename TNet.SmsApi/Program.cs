using FluentValidation;
using TNet.SmsApi.Infrastructure.Filters;
using TNet.SmsApi.Infrastructure.Validators;
using TNet.SmsApi.Core.Implementation.Providers;
using TNet.SmsApi.Core.Implementation.ProviderSelectors;
using TNet.SmsApi.Core.Implementation.Services;
using TNet.SmsApi.Core.Interfaces;
using TNet.SmsApi.Core.Interfaces.Services;
using TNet.SmsApi.Core.Models.Requests;
using TNet.SmsApi.Core.Models.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(x => x.Filters.Add(typeof(ResponseFilter)));
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<SendSmsRequestModel>, SendSmsValidator>();

builder.Services.AddScoped<ISmsProvider, BeelineProvider>();
builder.Services.AddScoped<ISmsProvider, GeocellProvider>();
builder.Services.AddScoped<ISmsProvider, MagtiProvider>();
//Add More Providers Here

builder.Services.AddSingleton<ISmsProviderSelector, PercentSmsProviderSelector>(); //Change Selector Here

builder.Services.AddScoped<ISmsService, SmsService>();

builder.Services.Configure<ProviderDistribution>(builder.Configuration.GetSection("ProviderDistribution"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();