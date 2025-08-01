using Webhookachu.Core.Interfaces;
using Webhookachu.Core.Models;
using Webhookachu.Core.Services;
using Webhookachu.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
.Configure<WebhookLogStorageOptions>(
    builder.Configuration.GetSection("WebhookLogStorage"));

builder.Services.AddSingleton<IWebhookLogReader, FileWebhookLogReader>();
builder.Services.AddSingleton<IWebhookLogWriter, FileWebhookLogWriter>();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapLogEndpoint();
app.MapLogsEndpoint();
app.MapSimulateWebhookEndpoint();

app.MapPing();
app.MapHealth();

app.Run();
