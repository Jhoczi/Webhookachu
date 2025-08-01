using System.Text.Json;

namespace Webhookachu.Contracts;

public class SimulateWebhookRequest
{
    public string Url { get; init; } = default!;
    public JsonElement Payload { get; init; }
}
