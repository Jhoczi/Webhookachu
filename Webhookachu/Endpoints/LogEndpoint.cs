using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Webhookachu.Core.Interfaces;
using Webhookachu.Core.Models;

namespace Webhookachu.Endpoints;

public static class LogEndpoint
{
    public static void MapLogEndpoint(this WebApplication app)
    {
        app.MapPost("/log", async (HttpContext context, IWebhookLogWriter writer) =>
        {
            var jsonBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var parsedBody = JsonSerializer.Deserialize<JsonElement>(jsonBody);

            var entry = new WebhookLogEntry
            {
                Timestamp = DateTime.UtcNow,
                IP = context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                UserAgent = context.Request.Headers.UserAgent.ToString(),
                BodyRaw = parsedBody,
                BodyHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(jsonBody)))
            };

            await writer.WriteLogAsync(entry);
            return Results.Ok(new { status = "Request logged successfully." });
        });
    }
}
