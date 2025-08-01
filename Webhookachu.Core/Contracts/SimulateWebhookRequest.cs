using System.Text.Json;

namespace Webhookachu.Core.Contracts;

public class SimulateWebhookRequest
{
    public string Url { get; init; } = default!;
    public JsonElement Payload { get; init; }
}
