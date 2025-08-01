namespace Webhookachu.Core.Interfaces;

public interface IWebhookLogReader
{
    Task<string> ReadLogAsync(int lastLines = 0);
}