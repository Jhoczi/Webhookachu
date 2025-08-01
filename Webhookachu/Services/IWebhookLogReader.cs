namespace Webhookachu.Services;

public interface IWebhookLogReader
{
    Task<string> ReadLogAsync(int lastLines = 0);
}