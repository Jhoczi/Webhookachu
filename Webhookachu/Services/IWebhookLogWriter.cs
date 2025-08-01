using Webhookachu.Models;

namespace Webhookachu.Services;

public interface IWebhookLogWriter
{
    Task WriteLogAsync(WebhookLogEntry entry);
}