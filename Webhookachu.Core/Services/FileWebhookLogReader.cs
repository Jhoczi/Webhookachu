

using Microsoft.Extensions.Options;
using Webhookachu.Core.Interfaces;
using Webhookachu.Core.Models;

namespace Webhookachu.Core.Services;

public class FileWebhookLogReader(IOptions<WebhookLogStorageOptions> options) : IWebhookLogReader
{
    private readonly string _path = options.Value.FilePath;

    public async Task<string> ReadLogAsync(int lastLines = 0)
    {
        if (!File.Exists(_path))
            return string.Empty;

        var lines = await File.ReadAllLinesAsync(_path);

        if (lastLines > 0)
            lines = [.. lines.TakeLast(lastLines)];

        return string.Join(Environment.NewLine, lines);
    }
}