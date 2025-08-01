using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Webhookachu.Endpoints;
using Webhookachu.Models;
using Webhookachu.Services;

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

app.Run();
