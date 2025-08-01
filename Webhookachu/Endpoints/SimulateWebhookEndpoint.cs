using System.Text;
using System.Text.Json;
using Webhookachu.Core.Contracts;

namespace Webhookachu.Endpoints;

public static class SimulateWebhookEndpoint
{
    public static void MapSimulateWebhookEndpoint(this WebApplication app)
    {
        app.MapPost("/simulateWebhook", async (
            SimulateWebhookRequest request,
            IHttpClientFactory httpClientFactory,
            ILoggerFactory loggerFactory) =>
        {
            var logger = loggerFactory.CreateLogger("SimulateWebhook");
            var client = httpClientFactory.CreateClient();

            var json = JsonSerializer.Serialize(request.Payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(request.Url, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                logger.LogInformation(
                    "Webhook sent to {Url}. Status: {StatusCode}. Response: {Body}",
                    request.Url,
                    response.StatusCode,
                    responseBody);

                return Results.Ok(new
                {
                    request.Url,
                    StatusCode = (int)response.StatusCode,
                    ResponseBody = responseBody
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error sending webhook to {Url}", request.Url);
                return Results.Problem($"Error sending webhook: {ex.Message}");
            }
        });
    }
}
