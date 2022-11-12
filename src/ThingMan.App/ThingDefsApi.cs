using ThingMan.Domain.Commands;
using ThingMan.Domain.Commands.Handlers;

namespace ThingMan.App;

public static class ThingDefsApi
{
    public static IEndpointConventionBuilder Map(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/thing-defs")
            .RequireAuthorization();

        retval.MapPost("/create", async (CreateThingDefCommand command, IHandleCreateThingDefCommand handler) =>
        {
            var id = 1;

            return Results.Ok(); //.Created($"/thing-defs/{id}");
        });

        return retval;
    }
}