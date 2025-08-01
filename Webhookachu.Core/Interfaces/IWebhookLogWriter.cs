using Webhookachu.Core.Models;

namespace Webhookachu.Core.Interfaces;

public interface IWebhookLogWriter
{
    Task WriteLogAsync(WebhookLogEntry entry);
}