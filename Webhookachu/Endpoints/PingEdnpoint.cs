namespace Webhookachu.Endpoints;

public static class PingEndpoint
{
    public static void MapPing(this WebApplication app)
    {
        app.MapGet("/ping", () => Results.Ok("pong"));
    }
}

