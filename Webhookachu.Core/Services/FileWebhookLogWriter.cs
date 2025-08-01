using System.Text.Json;
using Microsoft.Extensions.Options;
using Webhookachu.Core.Interfaces;
using Webhookachu.Core.Models;


namespace Webhookachu.Core.Services;

public class FileWebhookLogWriter(IOptions<WebhookLogStorageOptions> options) : IWebhookLogWriter
{
    private readonly string _path = options.Value.FilePath;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task WriteLogAsync(WebhookLogEntry entry)
    {
        var logObject = new
        {
            timestamp = entry.Timestamp.ToString("O"),
            ip = entry.IP,
            userAgent = entry.UserAgent,
            bodyHash = entry.BodyHash,
            body = entry.BodyRaw
        };

        var jsonLine = JsonSerializer.Serialize(logObject, _jsonOptions);
        await File.AppendAllTextAsync(_path, jsonLine + Environment.NewLine);
    }
}