using Webhookachu.Services;

namespace Webhookachu.Endpoints;

public static class LogsEndpoint
{
    public static void MapLogsEndpoint(this WebApplication app)
    {
        app.MapGet("/logs", async (HttpContext context, IWebhookLogReader reader) =>
        {
            var query = context.Request.Query;
            int lastLogsToDisplayAmount = 0;

            if (query.TryGetValue("last", out var lastParam) && int.TryParse(lastParam, out var parsed))
                lastLogsToDisplayAmount = parsed;

            var log = await reader.ReadLogAsync(lastLogsToDisplayAmount);
            return Results.Text(log, "text/plain");
        });
    }
}
