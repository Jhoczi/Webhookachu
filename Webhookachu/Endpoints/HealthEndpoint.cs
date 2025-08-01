using Webhookachu.Core.Interfaces;

namespace Webhookachu.Endpoints;

public static class HealthEndpoint
{
    public static void MapHealth(this WebApplication app)
    {
        app.MapGet("/health", () => Results.Ok("healthy"));
    }
}
