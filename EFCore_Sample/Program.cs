using EFCore_Sample.Helpers;
using EFCore_Sample.Infrastracture;
using EFCore_Sample.Job;
using EFCore_Sample.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using System.Text;
using Telegram.Bot;


Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);

if (OperatingSystem.IsLinux())
{
    var test = ExternMethods.EnsureGssInitialized();
}

ConfigurationApp.TGToken =
    builder.Configuration.GetSection("TGBot").GetSection("TGToken").Value;
ConfigurationApp.BotId =
    builder.Configuration.GetSection("TGBot").GetSection("BotId").Value;


ConfigurationApp.Environment = builder.Environment.EnvironmentName;

builder.Services.AddQuartz();


string schedule = "0 * * ? * *"; //"* * * * * ? *";
builder.Services.AddSingleton(new JobSchedule(typeof(CB_Process), schedule));

ITelegramBotClient bot = new TelegramBotClient(ConfigurationApp.TGToken);
builder.Services.AddSingleton(bot);


builder.Services.AddHostedService<JobConfigureServices>();

var app = builder.Build();

app.Run();



