using System.Text.Json;

namespace Webhookachu.Models;

public record WebhookLogEntry
{
    public DateTime Timestamp { get; init; }
    public string IP { get; init; } = string.Empty;
    public string UserAgent { get; init; } = string.Empty;
    public JsonElement BodyRaw { get; init; }
    public string BodyHash { get; init; } = string.Empty;
}